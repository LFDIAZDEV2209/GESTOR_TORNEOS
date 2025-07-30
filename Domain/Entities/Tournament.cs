namespace liga.Domain.Entities;

// Responsabilidad: Entidad de torneo
public class Tournament
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    // Temporalmente comentamos Teams hasta migrar Team
    // public List<Team> Teams { get; set; } = new List<Team>();

    public Tournament(int id, string? name, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Tournament() { }

    public override string ToString()
    {
        return $"Tournament: {Name} - {StartDate} - {EndDate}";
    }
} 