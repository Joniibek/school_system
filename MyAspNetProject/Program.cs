using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Behaviors;
using MyAspNetProject.Handlers;
using MyAspNetProject.Behaviors;
using MyAspNetProject.InfraStructure;
using MyAspNetProject.Middlewares;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IKlassRepository, KlassRepository>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();


// Registratsiya MediatR-a
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});


builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<DBContext>();


builder.Services.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline .
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Api v1"));
}

app.MapControllers();
// app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();
