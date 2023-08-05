using System.Collections.ObjectModel;
using CrudTest.Application.Customer.CreateCustomer;
using CrudTest.Application.Customer.DeleteCustomer;
using CrudTest.Application.Customer.Dtos;
using CrudTest.Application.Customer.GetAllCustomers;
using CrudTest.Application.Customer.GetCustomer;
using CrudTest.Application.Customer.QueryResults;
using CrudTest.Application.Customer.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<CreatedResult> CreateCustomer(CreateCustomerRequest createCustomerRequest)
    {
        var addedCustomer= await _mediator.Send(new CreateCustomerCommand(
            createCustomerRequest.Firstname,createCustomerRequest.Lastname,createCustomerRequest.DateOfBirth,
            createCustomerRequest.PhoneNumber,createCustomerRequest.Email,createCustomerRequest.BankAccountNumber));

        return Created("", addedCustomer);
    }

    [HttpGet]
    public async Task<ReadOnlyCollection<BaseCustomerQueryResult>> GetAllCustomers()
    {
        return await _mediator.Send(new GetAllCustomersQuery());
    }

    [HttpGet("{id:long}")]
    public async Task<BaseCustomerQueryResult> GetCustomer(long id)
    {
        return await _mediator.Send(new GetCustomerQuery(id));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
    {
        return Ok(await _mediator.Send(new UpdateCustomerCommand(updateCustomerRequest.Id,
            updateCustomerRequest.Firstname,updateCustomerRequest.Lastname,updateCustomerRequest.DateOfBirth,
            updateCustomerRequest.PhoneNumber,updateCustomerRequest.Email,updateCustomerRequest.BankAccountNumber)));
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteCustomer(long id)
    {
        return Ok(await _mediator.Send(new DeleteCustomerCommand(id)));
    }

    
}