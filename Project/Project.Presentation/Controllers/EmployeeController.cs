using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Employees.Commands.Add;
using Project.Application.Features.Employees.Commands.Delete;
using Project.Application.Features.Employees.Commands.Update;
using Project.Application.Features.Employees.Queries;
using Project.Application.Features.Employees.Queries.GetAll;
using Project.Application.Features.Employees.Queries.GetById;
using Project.Domain.Routes.BaseRouter;

namespace Project.Presentation.Controllers;

public class EmployeeController : BaseController
{
    [HttpPost(Router.EmployeeRouter.Add)]
    public async Task<IActionResult> Create(AddEmployeeCommand employeeCommand)
    {
        var result = await mediator.Send(employeeCommand);
        return Result(result);
    }
    
    [HttpDelete(Router.EmployeeRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteEmployeeCommand(id));
        return Result(result);
    }

    [HttpGet(Router.EmployeeRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery]GetAllEmployeesQuery request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }
    
    [HttpGet(Router.EmployeeRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id));
        return Result(result);
    }

    [HttpPut(Router.EmployeeRouter.Update)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand request)
    {
        request.Id = id; 
        var result = await mediator.Send(request);
        return Result(result);
    }


    
}