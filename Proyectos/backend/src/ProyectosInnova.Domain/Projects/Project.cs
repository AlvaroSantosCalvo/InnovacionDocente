namespace ProyectosInnova.Domain.Projects;

public sealed class Project
{
    public Project(
        int id,
        string title,
        string faculty,
        string responsible,
        string summary,
        string call,
        string academicYear,
        string line,
        string center)
    {
        Id = id;
        Title = title;
        Faculty = faculty;
        Responsible = responsible;
        Summary = summary;
        Call = call;
        AcademicYear = academicYear;
        Line = line;
        Center = center;
    }

    public int Id { get; }

    public string Title { get; }

    public string Faculty { get; }

    public string Responsible { get; }

    public string Summary { get; }

    public string Call { get; }

    public string AcademicYear { get; }

    public string Line { get; }

    public string Center { get; }
}
