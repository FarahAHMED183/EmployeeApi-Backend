using AutoMapper;
using Project.Application.Features.Employees.Commands.Add;
using Project.Application.Features.Employees.Commands.Update;
using Project.Application.Features.Employees.Dtos;
using EmployeeEntity = Project.Domain.Models.Employee.Employee;

namespace Project.Application.Mapping.Employee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeEntity, EmployeeDto>();
        CreateMap<EmployeeDto, EmployeeEntity>();

        CreateMap<AddEmployeeCommand, EmployeeEntity>();

        CreateMap<UpdateEmployeeCommand, EmployeeEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); 

    }
}