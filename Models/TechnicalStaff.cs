namespace liga.Models;

// Responsabilidad: Modelo de personal tecnico
public class TechnicalStaff : Person
{
    public string? Role { get; set; }

    public TechnicalStaff(int id, string? name, string? origen, string? email, string? role) : base(id, name, origen, email)
    {
        Id = id;
        Name = name;
        Origen = origen;
        Email = email;
        Role = role;
    }

    public TechnicalStaff() { }

    public override string ToString()
    {
        return $"TechnicalStaff: {Name} - {Role}";
    }
}