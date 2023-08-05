using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.DomainServices;

public interface IBankAccountValidatorDomainService:IDomainService
{
    public bool ValidateBankAccount(string bankAccountNumber);

}