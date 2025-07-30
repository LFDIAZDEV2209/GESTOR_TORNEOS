using liga.Domain.Entities;
using liga.Domain.Ports;

namespace liga.Application.Services;

// Responsabilidad: Servicio de aplicación para equipos
public class TeamService
{
    private readonly ITeamRepository _repo;

    public TeamService(ITeamRepository repo)
    {
        _repo = repo;
    }

    public List<Team> ObtenerTodos()
    {
        return _repo.ObtenerTodos();
    }

    public Team? ObtenerPorId(int id)
    {
        return _repo.ObtenerPorId(id);
    }

    public void CrearEquipo(string nombre, string ciudad)
    {
        var team = new Team
        {
            Name = nombre,
            City = ciudad
        };
        _repo.Crear(team);
    }

    public void EliminarEquipo(int id)
    {
        _repo.Eliminar(id);
    }

    public void ActualizarEquipo(int id, string nombre, string ciudad)
    {
        var team = new Team
        {
            Id = id,
            Name = nombre,
            City = ciudad
        };
        _repo.Actualizar(team);
    }

    public void InscribirTorneo(int teamId, int tournamentId)
    {
        _repo.InscribirTorneo(teamId, tournamentId);
    }

    public void SalirTorneo(int teamId, int tournamentId)
    {
        _repo.SalirTorneo(teamId, tournamentId);
    }
} 