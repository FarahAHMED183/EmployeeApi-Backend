using FluentValidation;
namespace Project.Application.Features.Employees.Queries.GetById;
public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdValidator()
    {
         RuleFor(e => e.Id).NotEmpty();
    }
}