using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Employee;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Commands.Delete;
public class DeleteEmployeeCommandHandler(IRepository<Employee> employeeRepository) : ICommandHandler<DeleteEmployeeCommand, Guid>
{
    public async Task<Response<Guid>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (employee is null)
        {
            return Response<Guid>.Failure("Employee not found.");
        }

        await employeeRepository.DeleteAsync(employee, cancellationToken);
        return Response<Guid>.Success(employee.Id);
    }
}