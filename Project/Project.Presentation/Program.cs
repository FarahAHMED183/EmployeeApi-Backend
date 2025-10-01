using Project.Application;
using Project.Infrastructure;
using Project.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;

builder
    .Services
    .AddApplication()
    .AddInfrastructure(configuration)
    .AddPresentation();

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseStaticFiles(); 

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();