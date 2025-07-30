using liga.Domain.Entities;
using liga.Domain.Ports;

namespace liga.Infrastructure.Repositories;

// Responsabilidad: Repositorio específico de torneos implementando su propia lógica
public class TournamentRepository : ITournamentRepository
{
    public List<Tournament> ObtenerTodos()
    {
        // Convertir de liga.Models.Tournament a liga.Domain.Entities.Tournament
        return Program.tournaments.Select(t => new Tournament
        {
            Id = t.Id,
            Name = t.Name,
            StartDate = t.StartDate,
            EndDate = t.EndDate
            // Teams se agregará cuando migremos Team
        }).ToList();
    }

    public Tournament? ObtenerPorId(int id)
    {
        var tournament = Program.tournaments.FirstOrDefault(t => t.Id == id);
        if (tournament == null) return null;

        return new Tournament
        {
            Id = tournament.Id,
            Name = tournament.Name,
            StartDate = tournament.StartDate,
            EndDate = tournament.EndDate
        };
    }

    public void Crear(Tournament tournament)
    {
        // 🔍 USANDO LINQ PARA ID AUTOINCREMENTAL
        var nextId = Program.tournaments.Count > 0 
            ? Program.tournaments.Max(t => t.Id) + 1 
            : 1;

        // Convertir a liga.Models.Tournament y agregar a Program.tournaments
        var newTournament = new liga.Models.Tournament(
            nextId,  // ✅ ID AUTOINCREMENTAL
            tournament.Name, 
            tournament.StartDate, 
            tournament.EndDate
        );
        // Teams se agregará cuando migremos Team
        Program.tournaments.Add(newTournament);
    }

    public void Eliminar(int id)
    {
        var tournament = Program.tournaments.FirstOrDefault(t => t.Id == id);
        if (tournament != null)
        {
            Program.tournaments.Remove(tournament);
        }
    }

    public void Actualizar(Tournament tournament)
    {
        var existingTournament = Program.tournaments.FirstOrDefault(t => t.Id == tournament.Id);
        if (existingTournament != null)
        {
            existingTournament.Name = tournament.Name;
            existingTournament.StartDate = tournament.StartDate;
            existingTournament.EndDate = tournament.EndDate;
            // Teams se agregará cuando migremos Team
        }
    }
} 