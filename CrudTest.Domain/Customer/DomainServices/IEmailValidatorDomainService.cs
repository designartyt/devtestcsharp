using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.DomainServices;

public interface IEmailValidatorDomainService:IDomainService
{
    public bool ValidateEmail(string emailAddress);
}