namespace liga.Domain.Ports;

// Responsabilidad: Puerto genérico para operaciones CRUD básicas
public interface IRepository<T> where T : class
{
    // ✅ OPERACIONES CRUD BÁSICAS
    List<T> ObtenerTodos();
    T? ObtenerPorId(int id);
    void Crear(T entity);
    void Eliminar(int id);
    void Actualizar(T entity);
} 