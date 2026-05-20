using Microsoft.Extensions.DependencyInjection;
using ProyectosInnova.Application.Abstractions;
using ProyectosInnova.Application.Projects;
using ProyectosInnova.Infrastructure.Persistence;

namespace ProyectosInnova.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IProjectRepository, InMemoryProjectRepository>();
        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}

