using CrudTest.Domain.Common;
using CrudTest.Domain.Customer.DomainServices;
using CrudTest.Domain.Customer.Events;
using CrudTest.Domain.Customer.Exceptions;

namespace CrudTest.Domain.Customer;

public class Customer :AggregateRoot
{
    protected Customer()
    {
        
    }
    public Customer(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email,
        string bankAccountNumber, IBankAccountValidatorDomainService bankAccountValidatorDomainService,
        IEmailValidatorDomainService emailValidatorDomainService, IPhoneNumberValidatorDomainService phoneNumberValidatorDomainService)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        if (!phoneNumberValidatorDomainService.ValidatePhoneNumber(phoneNumber))
            throw new InvalidPhoneNumberDomainException();
        PhoneNumber = phoneNumber;
        if (!emailValidatorDomainService.ValidateEmail(email))
            throw new InvalidEmailDomainException();
        Email = email;
        if (!bankAccountValidatorDomainService.ValidateBankAccount(bankAccountNumber))
            throw new InvalidBankAccountNumberDomainException();
        BankAccountNumber = bankAccountNumber;
        
        AddDomainEvent(new CustomerCreatedDomainEvent());
    }

    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }

    public void Update(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber,IBankAccountValidatorDomainService bankAccountValidatorDomainService,IEmailValidatorDomainService emailValidatorDomainService,IPhoneNumberValidatorDomainService phoneNumberValidatorDomainService)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        if (!phoneNumberValidatorDomainService.ValidatePhoneNumber(phoneNumber))
            throw new InvalidPhoneNumberDomainException();
        PhoneNumber = phoneNumber;
        if (!emailValidatorDomainService.ValidateEmail(email))
            throw new InvalidEmailDomainException();
        Email = email;
        if (!bankAccountValidatorDomainService.ValidateBankAccount(bankAccountNumber))
            throw new InvalidBankAccountNumberDomainException();
        BankAccountNumber = bankAccountNumber;
        
        AddDomainEvent(new CustomerUpdatedDomainEvent());
        
    }

    public void Delete()
    {
        AddDomainEvent(new CustomerDeletedDomainEvent());
    }
}