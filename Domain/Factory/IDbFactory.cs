using liga.Domain.Ports;

namespace liga.Domain.Factory;

// Responsabilidad: Factory para crear repositorios
public interface IDbFactory
{
    ITournamentRepository CrearTournamentRepository();
    ITeamRepository CrearTeamRepository();
} 