namespace liga.Domain.Entities;

// Responsabilidad: Entidad de cuerpo médico
public class MedicalStaff
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Specialty { get; set; }
    public int TeamId { get; set; }

    public MedicalStaff(int id, string? name, string? specialty, int teamId)
    {
        Id = id;
        Name = name;
        Specialty = specialty;
        TeamId = teamId;
    }

    public MedicalStaff() { }

    public override string ToString()
    {
        return $"MedicalStaff: {Name} - {Specialty}";
    }
} 