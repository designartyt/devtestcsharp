using CrudTest.Application.Customer.Dtos;
using CrudTest.Domain.Common;
using CrudTest.Domain.Customer.DomainServices;
using MediatR;


namespace CrudTest.Application.Customer.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCustomerDto>
{
    private readonly IRepository<Domain.Customer.Customer> _repository;
    private readonly IBankAccountValidatorDomainService _bankAccountValidatorDomainService;
    private readonly IEmailValidatorDomainService _emailValidatorDomainService;
    private readonly IPhoneNumberValidatorDomainService _phoneNumberValidatorDomainService;

    public CreateCustomerCommandHandler(IRepository<Domain.Customer.Customer> repository,IBankAccountValidatorDomainService bankAccountValidatorDomainService,IEmailValidatorDomainService emailValidatorDomainService,IPhoneNumberValidatorDomainService phoneNumberValidatorDomainService)
    {
        _repository = repository;
        _bankAccountValidatorDomainService = bankAccountValidatorDomainService;
        _emailValidatorDomainService = emailValidatorDomainService;
        _phoneNumberValidatorDomainService = phoneNumberValidatorDomainService;
    }

    public async Task<BaseCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
     var customer= await _repository.AddAsync(new Domain.Customer.Customer(
            request.Firstname,
            request.Lastname,
            request.DateOfBirth,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber,
            _bankAccountValidatorDomainService,
            _emailValidatorDomainService, 
            _phoneNumberValidatorDomainService));
       return new BaseCustomerDto(
           customer.Id,
           customer.Firstname,
           customer.Lastname,
           customer.DateOfBirth,
           customer.PhoneNumber,
           customer.Email,
           customer.BankAccountNumber);
    }
}

