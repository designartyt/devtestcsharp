using CrudTest.Application.Common;
using CrudTest.Domain.Common;
using CrudTest.Domain.Customer.DomainServices;
using CrudTest.Infrastructure.Domain.DomainServices.Customer;
using CrudTest.Infrastructure.Persistence;
using CrudTest.Infrastructure.Persistence.Repositories;
using CrudTest.Infrastructure.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CrudTest.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CustomerAppDbContext>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>))
       .AddScoped<IEventPublisher, EventPublisher>();
       return serviceCollection;
    }
    
    public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddScoped<IEmailValidatorDomainService, EmailValidatorDomainService>();
        serviceCollection.AddScoped<IBankAccountValidatorDomainService, BankAccountValidatorDomainService>();
        serviceCollection.AddScoped<IPhoneNumberValidatorDomainService, PhoneNumberValidatorDomainService>();
        return serviceCollection;
    }
}