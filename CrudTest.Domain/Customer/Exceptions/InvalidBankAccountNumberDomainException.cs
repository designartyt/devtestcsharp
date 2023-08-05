using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.Exceptions;

public class InvalidBankAccountNumberDomainException:DomainException
{
    public InvalidBankAccountNumberDomainException():base("Bank Account Number is invalid")
    {
        
    }
}