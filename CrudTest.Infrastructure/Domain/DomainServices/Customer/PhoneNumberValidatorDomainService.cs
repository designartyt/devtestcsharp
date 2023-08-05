using CrudTest.Domain.Customer.DomainServices;
using PhoneNumbers;

namespace CrudTest.Infrastructure.Domain.DomainServices.Customer;

public class PhoneNumberValidatorDomainService:IPhoneNumberValidatorDomainService
{
    public bool ValidatePhoneNumber(string phoneNumber)
    {
        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(phoneNumber, "US"));
        }
        catch (Exception e)
        {
            return false;
        }
    }
}