using liga.Domain.Entities;

namespace liga.Domain.Ports;

// Responsabilidad: Puerto específico para equipos heredando del genérico
public interface ITeamRepository : IRepository<liga.Domain.Entities.Team>
{
    void InscribirTorneo(int teamId, int tournamentId);
    void SalirTorneo(int teamId, int tournamentId);
} 