using CrudTest.Application.Common;

namespace CrudTest.Application.Customer.QueryResults;

public record BaseCustomerQueryResult(
    long Id,
    string Firstname,
    string Lastname,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : IQueryResult;
