using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Employees.Dtos;
using Project.Domain.Filters;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Queries.GetAll;
public record GetAllEmployeesQuery(string? Name) : BaseFilter, IQuery<PaginatedResult<EmployeeDto>>;