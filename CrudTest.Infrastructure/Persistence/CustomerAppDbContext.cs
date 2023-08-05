using CrudTest.Application.Common;
using CrudTest.Domain.Common;
using CrudTest.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CrudTest.Infrastructure.Persistence;

public class CustomerAppDbContext:DbContext
{
  private readonly IEventPublisher? _eventPublisher;

  public CustomerAppDbContext()
  {
      
  }
    public CustomerAppDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
                //optionsBuilder.UseSqlServer("Server=.;DataBase=CustomerDb;Trusted_Connection=True; Integrated Security = true;");
                optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");

        }
    }

     public CustomerAppDbContext(DbContextOptions options,IEventPublisher? eventPublisher): base(options)
    {
        _eventPublisher = eventPublisher;
    }
    
    DbSet<Customer> Customers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasIndex(customer =>
            new { customer.Firstname, customer.Lastname, customer.DateOfBirth })
            .IsUnique();

        modelBuilder.Entity<Customer>().HasIndex(customer => customer.Email).IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        
        int result = await base.SaveChangesAsync(cancellationToken);
        await SendDomainEventsAsync();
        return result;
    }
        
        private async Task SendDomainEventsAsync()
        {
            if(_eventPublisher is null)
                return;
            
            var entitiesWithEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents != null && e.DomainEvents.Any());

            var domainEvents = entitiesWithEvents
                .SelectMany(x => x.DomainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
                await _eventPublisher.PublishAsync(domainEvent);
        }
    
}