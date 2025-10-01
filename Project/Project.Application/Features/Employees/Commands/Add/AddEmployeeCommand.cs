using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.Employees.Commands.Add;

public record AddEmployeeCommand(string Name, string Address, int Age, decimal Salary) : ICommand<string>;