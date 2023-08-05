using CrudTest.Domain.Common;
using MediatR;

namespace CrudTest.Application.Customer.DeleteCustomer;

public class DeleteCustomerCommandHandler: IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IRepository<Domain.Customer.Customer> _repository;

    public DeleteCustomerCommandHandler(IRepository<Domain.Customer.Customer> repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id,cancellationToken);
        customer.Delete();
       await _repository.DeleteAsync(customer, cancellationToken);
       return true;
    }
}