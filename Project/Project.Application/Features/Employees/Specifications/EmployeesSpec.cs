using Ardalis.Specification;
using Project.Domain.Models.Employee;

namespace Project.Application.Features.Employees.Specifications;

public class EmployeeSpecification : Specification<Employee>
{
    public EmployeeSpecification(string? name, int pageSize, int pageNumber)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Query.Where(e => e.Name.Contains(name));
        }

       Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
}   
}