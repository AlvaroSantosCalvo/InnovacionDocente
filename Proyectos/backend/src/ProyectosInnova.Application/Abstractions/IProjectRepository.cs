using ProyectosInnova.Domain.Projects;

namespace ProyectosInnova.Application.Abstractions;

public interface IProjectRepository
{
    Task<IReadOnlyList<Project>> GetAllAsync(CancellationToken cancellationToken);

    Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken);
}

