using System.Collections.ObjectModel;
using CrudTest.Application.Customer.QueryResults;
using MediatR;

namespace CrudTest.Application.Customer.GetAllCustomers;

    public record GetAllCustomersQuery(): IRequest<ReadOnlyCollection<BaseCustomerQueryResult>>;
