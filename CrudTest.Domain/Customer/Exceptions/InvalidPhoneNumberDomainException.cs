using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.Exceptions;

public class InvalidPhoneNumberDomainException:DomainException
{
    public InvalidPhoneNumberDomainException():base("Phone number is Invalid")
    {
        
    }
}