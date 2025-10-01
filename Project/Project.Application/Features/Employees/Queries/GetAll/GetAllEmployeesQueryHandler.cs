using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Employees.Dtos;
using Project.Application.Features.Employees.Specifications;
using Project.Domain.Models.Employee;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Queries.GetAll;

public class GetAllEmployeesQueryHandler(IMapper mapper, IRepository<Employee> employeeRepository) : IQueryHandler<GetAllEmployeesQuery, PaginatedResult<EmployeeDto>>
{
    public async Task<Response<PaginatedResult<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.ListAsync(
            new EmployeeSpecification(request.Name, request.PageSize, request.PageNumber),
            cancellationToken);

        var totalEmployees = await employeeRepository.CountAsync(
            new EmployeeSpecification(request.Name,
                request.PageSize,
                request.PageNumber), cancellationToken);

        var mappedEmployees = mapper.Map<List<EmployeeDto>>(employees).AsEnumerable();
        return Response<PaginatedResult<EmployeeDto>>.GetData(mappedEmployees, request.PageNumber, request.PageSize, totalEmployees);
    }
}