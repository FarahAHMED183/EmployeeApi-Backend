using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Employees.Dtos;

namespace Project.Application.Features.Employees.Queries.GetById;
public record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeDto>;