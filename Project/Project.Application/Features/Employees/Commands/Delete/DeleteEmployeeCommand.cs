using Project.Application.Abstractions.Messaging;
using Project.Domain.Responses;

namespace Project.Application.Features.Employees.Commands.Delete;
public record DeleteEmployeeCommand(Guid Id) : ICommand<Guid>;