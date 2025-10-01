using FluentValidation;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models;
using Project.Domain.Models.Employee;

namespace Project.Application.Features.Employees.Commands.Add;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeValidator(IRepository<Employee> employeeRepository)
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(e => e.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

        RuleFor(e => e.Age)
            .GreaterThan(0).WithMessage("Age must be a positive number.");

        RuleFor(e => e.Salary)
            .GreaterThan(0).WithMessage("Salary must be a positive number.");
    }
}
