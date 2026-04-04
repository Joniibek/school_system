using FluentValidation;
using FluentValidation.AspNetCore;
using MyAspNetProject.Middlewares;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Repositories;
using MyAspNetProject.Services;
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

builder.Services.AddScoped<IStudentService, StudentGetService>();
builder.Services.AddScoped<IKlassService, KlassService>();
builder.Services.AddScoped<IKlassRepository, KlassRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Api v1"));
}

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();
