namespace ProyectosInnova.Application.Projects;

public interface IProjectService
{
    Task<IReadOnlyList<ProjectDto>> GetProjectsAsync(ProjectQuery query, CancellationToken cancellationToken);

    Task<ProjectDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}

