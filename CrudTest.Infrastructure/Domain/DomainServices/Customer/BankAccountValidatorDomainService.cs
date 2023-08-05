using CrudTest.Domain.Customer.DomainServices;
using IbanNet;

namespace CrudTest.Infrastructure.Domain.DomainServices.Customer;

public class BankAccountValidatorDomainService:IBankAccountValidatorDomainService
{
    public bool ValidateBankAccount(string bankAccountNumber)
    {
        IIbanValidator validator = new IbanValidator();
        return validator.Validate(bankAccountNumber).IsValid;
    }
}