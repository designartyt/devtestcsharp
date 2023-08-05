using AutoFixture;
using CrudTest.Domain.Customer.DomainServices;
using CrudTest.Infrastructure.Domain.DomainServices.Customer;
using NSubstitute;

namespace CrudTest.Test.TestUtilities;

public class CustomerFactory
{
    private readonly Fixture _fixture;

    public CustomerFactory(Fixture fixture)
    {
        _fixture = fixture;
    }

    public Domain.Customer.Customer CreateBaseCustomer()
    {
       
       return new Domain.Customer.Customer(
            "hassan",
            "noanahal",
            DateTime.Now, 
            "2024561111",
            "hassannonahal@gmail.com",
            "DE89370400440532013000",
           new BankAccountValidatorDomainService(), // no mocking need for this app
            new EmailValidatorDomainService(),
            new PhoneNumberValidatorDomainService()
            );
 
    }
    
    public Domain.Customer.Customer CreateCustomerWithValues(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        
        return new Domain.Customer.Customer(
            firstname,
            lastname,
            dateOfBirth, 
            phoneNumber,
            email,
            bankAccountNumber,
            new BankAccountValidatorDomainService(), // no mocking need for this app
            new EmailValidatorDomainService(),
            new PhoneNumberValidatorDomainService()
        );
 
    }
    
}