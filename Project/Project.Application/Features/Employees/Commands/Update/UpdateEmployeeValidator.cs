using FluentValidation;
namespace Project.Application.Features.Employees.Commands.Update;
public class UpdateEmployeeValidator: AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(e=>e.Id)
            .NotEmpty().WithMessage("Employee ID is required.");
    }
    
}