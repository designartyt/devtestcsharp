using CrudTest.Application.Common;

namespace CrudTest.Application.Customer.Dtos;

public record BaseCustomerDto(
    long Id,
    string Firstname,
    string Lastname,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : IDto;
