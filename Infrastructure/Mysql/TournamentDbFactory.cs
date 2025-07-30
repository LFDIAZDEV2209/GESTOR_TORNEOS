using liga.Domain.Factory;
using liga.Domain.Ports;
using liga.Infrastructure.Repositories;

namespace liga.Infrastructure.Mysql;

// Responsabilidad: Factory concreta para crear repositorios de torneos
public class TournamentDbFactory : IDbFactory
{
    public ITournamentRepository CrearTournamentRepository()
    {
        return new TournamentRepository();
    }
} 