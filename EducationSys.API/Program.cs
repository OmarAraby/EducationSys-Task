using EducationSys.Application.DependencyInjection;
using EducationSys.Infrastructure.DependencyInjection;
using FastEndpoints;
using FluentValidation.AspNetCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddFluentValidationAutoValidation();

// Add FastEndpoints
builder.Services.AddFastEndpoints();

builder.Services.AddAuthorization();

// Dependency Injection setup
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api"; // All routes start with /api
});

app.Run();
