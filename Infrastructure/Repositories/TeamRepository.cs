using liga.Domain.Entities;
using liga.Domain.Ports;

namespace liga.Infrastructure.Repositories;

// Responsabilidad: Repositorio específico de equipos implementando su propia lógica
public class TeamRepository : ITeamRepository
{
    public List<Team> ObtenerTodos()
    {
        // Convertir de liga.Models.Team a liga.Domain.Entities.Team
        return Program.teams.Select(t => new Team
        {
            Id = t.Id,
            Name = t.Name,
            City = t.City
            // Players, TechnicalStaffs, MedicalStaffs se agregarán cuando migremos esas entidades
        }).ToList();
    }

    public Team? ObtenerPorId(int id)
    {
        var team = Program.teams.FirstOrDefault(t => t.Id == id);
        if (team == null) return null;

        return new Team
        {
            Id = team.Id,
            Name = team.Name,
            City = team.City
        };
    }

    public void Crear(Team team)
    {
        // 🔍 USANDO LINQ PARA ID AUTOINCREMENTAL
        var nextId = Program.teams.Count > 0 
            ? Program.teams.Max(t => t.Id) + 1 
            : 1;

        // Convertir a liga.Models.Team y agregar a Program.teams
        var newTeam = new liga.Models.Team(
            nextId,  // ✅ ID AUTOINCREMENTAL
            team.Name, 
            team.City
        );
        Program.teams.Add(newTeam);
    }

    public void Eliminar(int id)
    {
        var team = Program.teams.FirstOrDefault(t => t.Id == id);
        if (team != null)
        {
            Program.teams.Remove(team);
        }
    }

    public void Actualizar(Team team)
    {
        var existingTeam = Program.teams.FirstOrDefault(t => t.Id == team.Id);
        if (existingTeam != null)
        {
            existingTeam.Name = team.Name;
            existingTeam.City = team.City;
        }
    }
} 