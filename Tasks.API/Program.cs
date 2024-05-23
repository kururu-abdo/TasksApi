using Tasks.Application.Abstractions;
using Tasks.Application.Task.Commands;
using Tasks.Infrastructure.Repositories;
using Tasks.Application;
using Tasks.Infrastructure;
using System.Reflection;
using Tasks.Application.Task.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add layers
builder.Services.
    AddApplication()
    .AddInfrastructure()
    ;


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<ITaskRepository, TaskRepsitory>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

