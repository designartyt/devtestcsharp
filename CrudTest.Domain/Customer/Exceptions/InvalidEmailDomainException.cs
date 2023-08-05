using CrudTest.Domain.Common;

namespace CrudTest.Domain.Customer.Exceptions;

public class InvalidEmailDomainException:DomainException
{
    public InvalidEmailDomainException():base("Email is invalid")
    {
        
    }
}