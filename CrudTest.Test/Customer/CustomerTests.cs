using System.Runtime.Serialization;
using NUnit.Framework;
using AutoFixture;
using AutoFixture.NUnit3;
using CrudTest.Domain.Customer.DomainServices;
using CrudTest.Domain.Customer.Events;
using CrudTest.Domain.Customer.Exceptions;
using CrudTest.Infrastructure.Domain.DomainServices.Customer;
using CrudTest.Test.TestUtilities;
using FluentAssertions;
using NSubstitute;

namespace CrudTest.Test.Customer;

[TestFixture]
public class CustomerTests
{
    private Fixture _fixture;
    private CustomerFactory _customerFactory;

    [OneTimeSetUp]
    public virtual void InitialSetup()
    {
        // this is called once per test fixture
    }

    [OneTimeTearDown]
    public virtual void FinalCleanup()
    {
        // this is called once per test fixture
    }

    [SetUp]
    public virtual void PerTestSetup()
    {
        _fixture = new Fixture();
        _customerFactory = new CustomerFactory(_fixture);
    }

    [TearDown]
    public virtual void PerTestCleanup()
    {
    }

    class creating_customer : CustomerTests
    {
        [Test]
        public async Task should_work()
        {
            var customer = _customerFactory.CreateBaseCustomer();
            customer.DomainEvents.Should().NotBeEmpty();
            customer.DomainEvents.Should().HaveCount(1);
            customer.DomainEvents.OfType<CustomerCreatedDomainEvent>().Should().HaveCount(1);
        }

        [Test]
        public async Task should_throw_InvalidPhoneNumberDomainException_for_invalid_phoneNumber()
        {
            var act = () =>
            {
                var customer = _customerFactory.CreateCustomerWithValues("hassan", "noanahal", DateTime.Now,
                    "invalidPhoneNumber", "hassannonahal@gmail.com", "DE89370400440532013000");
            };
            act.Should().Throw<InvalidPhoneNumberDomainException>();
        }

        [Test]
        public async Task should_throw_InvalidBankAccountNumberDomainException_for_invalid_bank_account_number()
        {
            var act = () =>
            {
                var customer = _customerFactory.CreateCustomerWithValues("hassan", "noanahal", DateTime.Now,
                    "2024561111", "hassannonahal@gmail.com", "invalidBankAccountNumber");
            };
            act.Should().Throw<InvalidBankAccountNumberDomainException>();
        }


        [Test]
        public async Task should_throw_InvalidEmailDomainException_for_invalid_email_address()
        {
            var act = () =>
            {
                var customer = _customerFactory.CreateCustomerWithValues("hassan", "noanahal", DateTime.Now,
                    "2024561111", "invalidEmailAddress", "DE89370400440532013000");
            };
            act.Should().Throw<InvalidEmailDomainException>();
        }
    }

    class customer_phoneNumber : CustomerTests
    {
        [Test]
        [TestCase("+989121234567",true)]
        [TestCase("+982188776655",false)]
        [TestCase("+16156381234",true)]
        public void should_phone_number_validation_result_as_expected_validation_result(string phoneNumber,bool expectedValidationResult)
        {
            var phoneNumberValidatorDomainService = new PhoneNumberValidatorDomainService();
            var result=phoneNumberValidatorDomainService.ValidatePhoneNumber(phoneNumber);

            result.Should().Be(expectedValidationResult);
        }
    }
    
    class updating_customer : CustomerTests
    {
        [Test]
        public async Task should_work()
        {
            var customer = _customerFactory.CreateBaseCustomer();
            // no mocking need for this app
            var bankAccountValidatorDomainService = new BankAccountValidatorDomainService();
            var emailValidatorDomainService = new EmailValidatorDomainService();
            var phoneNumberValidatorDomainService = new PhoneNumberValidatorDomainService();
            customer.Update("newFirstName", "newLast", DateTime.Now, "2024561111", "new@gmail.com",
                "DE89370400440532013000", bankAccountValidatorDomainService, emailValidatorDomainService,
                phoneNumberValidatorDomainService);
            customer.DomainEvents.Should().NotBeEmpty();
            customer.DomainEvents.OfType<CustomerUpdatedDomainEvent>().Should().HaveCount(1);
        }
    }
}