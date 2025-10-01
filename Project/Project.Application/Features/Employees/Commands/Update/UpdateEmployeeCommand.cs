using System.Text.Json.Serialization;
using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.Employees.Commands.Update;
public record UpdateEmployeeCommand(string Name, string Address, int Age, decimal Salary) : ICommand<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}


