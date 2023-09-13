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
            PhoneNumberType phoneNumberType = phoneNumberUtil.GetNumberType(phoneNumberUtil.Parse(phoneNumber, string.Empty));
            
            if (phoneNumberType == PhoneNumberType.MOBILE || 
                phoneNumberType == PhoneNumberType.FIXED_LINE_OR_MOBILE)
                return true;
            return false;
        }
        catch (NumberParseException e)
        {
            return false;
        }
    }
}