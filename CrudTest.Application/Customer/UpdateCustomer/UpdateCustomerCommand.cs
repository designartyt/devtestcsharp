using CrudTest.Application.Customer.Dtos;
using MediatR;

namespace CrudTest.Application.Customer.UpdateCustomer;

public record UpdateCustomerCommand(long Id, string Firstname, string Lastname, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber) : IRequest<BaseCustomerDto>;

