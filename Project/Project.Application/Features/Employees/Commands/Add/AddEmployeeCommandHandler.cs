using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Employee;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Commands.Add;

public class AddEmployeeCommandHandler(IMapper mapper, IRepository<Employee> employeeRepository) 
    : ICommandHandler<AddEmployeeCommand, string>
{
    public async Task<Response<string>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(request);

        await employeeRepository.AddAsync(employee, cancellationToken);

        return Response<string>.Success("Employee created successfully");
    }
}