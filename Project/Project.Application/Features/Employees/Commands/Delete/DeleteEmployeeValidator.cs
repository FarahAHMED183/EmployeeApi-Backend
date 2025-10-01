using FluentValidation;

namespace Project.Application.Features.Employees.Commands.Delete;
public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty().WithMessage("Employee ID is required.");
    }
}