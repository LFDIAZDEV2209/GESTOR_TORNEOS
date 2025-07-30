using liga.Domain.Entities;
using liga.Domain.Ports;

namespace liga.Application.Services;

// Responsabilidad: Servicio de aplicación para torneos
public class TournamentService
{
    private readonly ITournamentRepository _repo;

    public TournamentService(ITournamentRepository repo)
    {
        _repo = repo;
    }

    public List<Tournament> ObtenerTodos()
    {
        return _repo.ObtenerTodos();
    }

    public void CrearTorneo(string nombre, DateTime fechaInicio, DateTime fechaFin)
    {
        var tournament = new Tournament(0, nombre, fechaInicio, fechaFin);
        _repo.Crear(tournament);
    }

    public void EliminarTorneo(int id)
    {
        _repo.Eliminar(id);
    }

    public void ActualizarTorneo(int id, string nombre, DateTime fechaInicio, DateTime fechaFin)
    {
        var tournament = new Tournament(id, nombre, fechaInicio, fechaFin);
        _repo.Actualizar(tournament);
    }
} 