using System.Collections.ObjectModel;
using CrudTest.Application.Customer.QueryResults;
using CrudTest.Domain.Common;
using MediatR;

namespace CrudTest.Application.Customer.GetAllCustomers;

public class GetAllCustomersQueryHandler:IRequestHandler<GetAllCustomersQuery, ReadOnlyCollection<BaseCustomerQueryResult>>
{
    private readonly IRepository<Domain.Customer.Customer> _repository;

    public GetAllCustomersQueryHandler(IRepository<Domain.Customer.Customer> repository)
    {
        _repository = repository;
    }
    public async Task<ReadOnlyCollection<BaseCustomerQueryResult>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers= await _repository.ListAsync(cancellationToken);
        return customers.ConvertAll(customer => new BaseCustomerQueryResult(customer.Id, 
            customer.Firstname,
            customer.Lastname,
            customer.DateOfBirth,
            customer.PhoneNumber,
            customer.Email,
            customer.BankAccountNumber)).AsReadOnly();
    }
}