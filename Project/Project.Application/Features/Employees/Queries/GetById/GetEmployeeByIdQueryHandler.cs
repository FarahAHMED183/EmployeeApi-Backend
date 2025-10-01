using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Employees.Dtos;
using Project.Domain.Models;
using Project.Domain.Models.Employee;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Queries.GetById;

public class GetEmployeeByIdQueryHandler(IMapper mapper, IRepository<Employee> employeeRepository) : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    public async Task<Response<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            return Response<EmployeeDto>.NotFound("Employee not found.");
        }

        var mappedEmployee = mapper.Map<EmployeeDto>(employee);
        return Response<EmployeeDto>.Success(mappedEmployee);
    }
}