using CrudTest.Domain.Common;
using CrudTest.Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Infrastructure.Persistence.Repositories;

public class Repository<T>:IRepository<T> where T : AggregateRoot
{
    private CustomerAppDbContext _dbContext;
    public Repository(CustomerAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().SingleAsync(entity=>entity.Id==id);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
       _dbContext.Set<T>().Add(entity);
       await SaveChangesAsync(cancellationToken);
       return entity;
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
       await SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}