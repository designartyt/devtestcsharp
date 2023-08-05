using CrudTest.Application.Customer.QueryResults;
using MediatR;

namespace CrudTest.Application.Customer.GetCustomer;
  
public record GetCustomerQuery(long Id): IRequest<BaseCustomerQueryResult>;
  