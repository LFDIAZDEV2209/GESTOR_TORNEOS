using liga.Domain.Entities;
using liga.Domain.Ports;

namespace liga.Infrastructure.Repositories;

// Responsabilidad: Repositorio específico de equipos implementando su propia lógica
public class TeamRepository : ITeamRepository
{
    public List<Team> ObtenerTodos()
    {
        // Convertir de Program.teams a liga.Domain.Entities.Team
        return Program.teams.Select(t => new Team
        {
            Id = t.Id,
            Name = t.Name,
            City = t.City,
            Tournaments = t.Tournaments ?? new List<int>()
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
            City = team.City,
            Tournaments = team.Tournaments ?? new List<int>()
        };
    }

    public void Crear(Team team)
    {
        // 🔍 USANDO LINQ PARA ID AUTOINCREMENTAL
        var nextId = Program.teams.Count > 0 
            ? Program.teams.Max(t => t.Id) + 1 
            : 1;

        // Asignar ID y agregar a Program.teams
        team.Id = nextId; // ✅ ID AUTOINCREMENTAL
        Program.teams.Add(team);
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
            existingTeam.Tournaments = team.Tournaments ?? new List<int>();
        }
    }

    public void InscribirTorneo(int teamId, int tournamentId)
    {
        var team = Program.teams.FirstOrDefault(t => t.Id == teamId);
        if (team != null)
        {
            if (team.Tournaments == null)
                team.Tournaments = new List<int>();
            
            if (!team.Tournaments.Contains(tournamentId))
                team.Tournaments.Add(tournamentId);
        }
    }

    public void SalirTorneo(int teamId, int tournamentId)
    {
        var team = Program.teams.FirstOrDefault(t => t.Id == teamId);
        if (team != null && team.Tournaments != null)
        {
            team.Tournaments.Remove(tournamentId);
        }
    }
} 