using CrudTest.Application.Customer.QueryResults;
using CrudTest.Domain.Common;
using MediatR;

namespace CrudTest.Application.Customer.GetCustomer;

public class GetCustomerQueryHandler:IRequestHandler<GetCustomerQuery, BaseCustomerQueryResult>
{
    private readonly IRepository<Domain.Customer.Customer> _repository;

    public GetCustomerQueryHandler(IRepository<Domain.Customer.Customer> repository)
    {
        _repository = repository;
    }
    public async Task<BaseCustomerQueryResult> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer=await _repository.GetByIdAsync(request.Id);
        return new BaseCustomerQueryResult(
            customer.Id,
            customer.Firstname,
            customer.Lastname,
            customer.DateOfBirth,
            customer.PhoneNumber,
            customer.Email,
            customer.BankAccountNumber
            );
    }
}

