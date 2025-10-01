namespace Project.Application.Features.Employees.Dtos;

public record EmployeeDto(Guid Id, string Name, string Address, int Age, decimal Salary);