namespace ProyectosInnova.Application.Projects;

public sealed record ProjectDto(
    int Id,
    string Title,
    string Faculty,
    string Responsible,
    string Summary,
    string Call,
    string AcademicYear,
    string Line,
    string Center);
