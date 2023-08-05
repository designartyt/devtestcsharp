using CrudTest.Application.Customer.Dtos;
using MediatR;

namespace CrudTest.Application.Customer.CreateCustomer;

public record CreateCustomerCommand(string Firstname, string Lastname, DateTime DateOfBirth, string PhoneNumber, string Email, string BankAccountNumber): IRequest<BaseCustomerDto>;
