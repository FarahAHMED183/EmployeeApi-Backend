using Project.Domain.Models.Base;

namespace Project.Domain.Models.Employee;

public class Employee : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
}