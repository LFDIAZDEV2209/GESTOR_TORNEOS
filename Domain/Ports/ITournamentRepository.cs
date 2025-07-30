using liga.Domain.Entities;

namespace liga.Domain.Ports;

// Responsabilidad: Puerto para operaciones de torneos
public interface ITournamentRepository
{
    List<Tournament> ObtenerTodos();
    void Crear(Tournament tournament);
    void Eliminar(int id);
    void Actualizar(Tournament tournament);
} 