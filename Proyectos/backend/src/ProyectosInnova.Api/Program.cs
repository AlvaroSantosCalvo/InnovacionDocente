using Microsoft.AspNetCore.Mvc;
using ProyectosInnova.Application.Projects;
using ProyectosInnova.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("frontend");

app.MapGet("/api/projects", async (
    [AsParameters] ProjectQuery query,
    IProjectService service,
    CancellationToken cancellationToken) =>
{
    var projects = await service.GetProjectsAsync(query, cancellationToken);
    return Results.Ok(projects);
});

app.MapGet("/api/projects/{id:int}", async (
    int id,
    IProjectService service,
    CancellationToken cancellationToken) =>
{
    var project = await service.GetByIdAsync(id, cancellationToken);
    return project is null ? Results.NotFound() : Results.Ok(project);
});

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
