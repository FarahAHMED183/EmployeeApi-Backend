using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Employee;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommandHandler(IMapper mapper,IRepository<Employee> employeeRepository) :
    ICommandHandler<UpdateEmployeeCommand, Guid>
{

    
    public async Task<Response<Guid>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var existingEmployee = await employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingEmployee == null)
        {
            return Response<Guid>.NotFound("Employee not found.");
        }

        var updatedEmployee = mapper.Map(request, existingEmployee);
        await employeeRepository.UpdateAsync(updatedEmployee, cancellationToken);

        return Response<Guid>.Success(updatedEmployee.Id);
    }
}