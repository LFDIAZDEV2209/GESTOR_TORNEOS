using liga.Domain.Entities;

namespace liga.Domain.Ports;

// Responsabilidad: Puerto específico para equipos heredando del genérico
public interface ITeamRepository : IRepository<liga.Domain.Entities.Team>
{
    // ✅ HEREDA TODAS LAS OPERACIONES CRUD DEL GENÉRICO
    // ✅ PUEDE AGREGAR MÉTODOS ESPECÍFICOS SI ES NECESARIO
} 