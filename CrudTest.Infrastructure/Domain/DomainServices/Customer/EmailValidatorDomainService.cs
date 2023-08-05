using CrudTest.Domain.Customer.DomainServices;
using EmailValidation;

namespace CrudTest.Infrastructure.Domain.DomainServices.Customer;

public class EmailValidatorDomainService:IEmailValidatorDomainService
{
    public bool ValidateEmail(string emailAddress)
    {
        return EmailValidator.Validate(emailAddress);
    }
}