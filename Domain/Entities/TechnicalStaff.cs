namespace liga.Domain.Entities;

// Responsabilidad: Entidad de cuerpo técnico
public class TechnicalStaff
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public int TeamId { get; set; }

    public TechnicalStaff(int id, string? name, string? role, int teamId)
    {
        Id = id;
        Name = name;
        Role = role;
        TeamId = teamId;
    }

    public TechnicalStaff() { }

    public override string ToString()
    {
        return $"TechnicalStaff: {Name} - {Role}";
    }
} 