using MediatR;

namespace CrudTest.Application.Customer.DeleteCustomer;

    public record DeleteCustomerCommand(long Id) : IRequest<bool>;
    