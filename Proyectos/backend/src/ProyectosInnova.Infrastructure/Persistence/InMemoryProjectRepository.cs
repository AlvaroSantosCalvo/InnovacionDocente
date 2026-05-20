using ProyectosInnova.Application.Abstractions;
using ProyectosInnova.Domain.Projects;

namespace ProyectosInnova.Infrastructure.Persistence;

public sealed class InMemoryProjectRepository : IProjectRepository
{
    private static readonly IReadOnlyList<Project> Projects = SeedData();

    public Task<IReadOnlyList<Project>> GetAllAsync(CancellationToken cancellationToken)
        => Task.FromResult(Projects);

    public Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => Task.FromResult(Projects.FirstOrDefault(project => project.Id == id));

    private static IReadOnlyList<Project> SeedData() =>
    [
        new Project(
            1,
            "Reflexion critica y autopercepcion juvenil",
            "Facultad de Comunicacion y Artes",
            "",
            "Diagnostico participativo del estudiantado universitario ante el contexto actual.",
            "INNOVA",
            "2024/2025",
            "Pedagogia critica",
            "Cualquiera"),
        new Project(
            2,
            "El cuerpo en el arte",
            "Facultad de Educacion",
            "",
            "Analisis de la expresion corporal a traves de la pintura en el Museo Thyssen.",
            "INNOVA",
            "2024/2025",
            "Aprendizaje experiencial",
            "Cualquiera"),
        new Project(
            3,
            "Descansos activos en universitarios",
            "Facultad de Ciencias de la Salud",
            "Evelyn Martín Moraleda",
            "Incorporacion de snacks de ejercicio saludable en el aula para combatir sedentarismo y fatiga cognitiva.",
            "INNOVA",
            "2024/2025",
            "Salud y bienestar",
            "Cualquiera"),
        new Project(
            4,
            "La opera como recurso pedagogico",
            "Facultad de Lenguas y Educacion",
            "",
            "Uso de la opera como eje interdisciplinar para desarrollar metodologias activas y educacion en valores.",
            "INNOVA",
            "2024/2025",
            "Aprendizaje experiencial",
            "Cualquiera"),
        new Project(
            5,
            "WinSTEAM",
            "Escuela Politecnica Superior",
            "",
            "Analisis de la autopercepcion para afrontar la brecha de genero en titulaciones STEAM mediante tutorizacion inclusiva.",
            "INNOVA",
            "2024/2025",
            "Igualdad de genero",
            "Cualquiera"),
        new Project(
            6,
            "FEEL-AI",
            "Facultad de Lenguas y Educacion",
            "Ocarina Masid Blanco",
            "Integracion critica de la inteligencia artificial generativa en la formacion de profesores de lenguas extranjeras.",
            "INNOVA",
            "2024/2025",
            "Inteligencia artificial",
            "Cualquiera"),
        new Project(
            7,
            "Comunicar para aprender, aprender a comunicar",
            "Institutos de Competencias Profesionales",
            "",
            "Proyecto de co-docencia e innovacion en competencias profesionales para mejorar la expresion escrita y oral.",
            "INNOVA",
            "2024/2025",
            "Competencias transversales",
            "Cualquiera"),
        new Project(
            8,
            "CONEXIA",
            "Facultad de Economia y Empresa",
            "",
            "Conectando aulas y empresas mediante retos de negocio reales y aprendizaje basado en el trabajo.",
            "INNOVA",
            "2024/2025",
            "Empleabilidad",
            "Cualquiera"),
        new Project(
            9,
            "Pedagogias Visibles",
            "Facultad de Comunicacion y Artes",
            "",
            "Innovacion docente y aprendizaje situado en contextos profesionales del arte contemporaneo.",
            "INNOVA",
            "2024/2025",
            "Arte y cultura",
            "Cualquiera"),
        new Project(
            10,
            "Reenactment eco-corporeo",
            "Facultad de Artes",
            "",
            "Narrativas performativas para consolidar identidades creativas desde la investigacion-creacion transdisciplinar.",
            "INNOVA",
            "2024/2025",
            "Transdisciplinar",
            "Cualquiera")
    ];
}
