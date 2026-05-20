using ProyectosInnova.Application.Abstractions;
using ProyectosInnova.Domain.Projects;

namespace ProyectosInnova.Application.Projects;

public sealed class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ProjectDto>> GetProjectsAsync(ProjectQuery query, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync(cancellationToken);

        var filtered = projects.Where(project =>
        {
            var matchesSearch = string.IsNullOrWhiteSpace(query.Search)
                || Contains(project.Title, query.Search)
                || Contains(project.Faculty, query.Search)
                || Contains(project.Summary, query.Search);

            var matchesAcademicYear = string.IsNullOrWhiteSpace(query.AcademicYear) || query.AcademicYear == "Todos"
                || project.AcademicYear == query.AcademicYear;
            var matchesLine = string.IsNullOrWhiteSpace(query.Line) || query.Line == "Todas"
                || project.Line == query.Line;
            var matchesCall = string.IsNullOrWhiteSpace(query.Call) || query.Call == "Cualquiera"
                || project.Call == query.Call;
            var matchesCenter = string.IsNullOrWhiteSpace(query.Center) || query.Center == "Cualquiera"
                || project.Center == query.Center;

            return matchesSearch && matchesAcademicYear && matchesLine && matchesCall && matchesCenter;
        });

        var skip = query.Skip.GetValueOrDefault(0);
        var take = query.Take.GetValueOrDefault(100);

        return filtered
            .Skip(skip)
            .Take(take)
            .Select(Map)
            .ToArray();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(id, cancellationToken);
        return project is null ? null : Map(project);
    }

    private static bool Contains(string value, string search) =>
        value.Contains(search, StringComparison.InvariantCultureIgnoreCase);

    private static ProjectDto Map(Project project) =>
        new(
            project.Id,
            project.Title,
            project.Faculty,
            project.Responsible,
            project.Summary,
            project.Call,
            project.AcademicYear,
            project.Line,
            project.Center);
}
