using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.DomainServices;

public interface IPhoneNumberValidatorDomainService:IDomainService
{
    public bool ValidatePhoneNumber(string phoneNumber);
}