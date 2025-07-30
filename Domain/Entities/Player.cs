namespace liga.Domain.Entities;

// Responsabilidad: Entidad de jugador
public class Player
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Position { get; set; }
    public int TeamId { get; set; }

    public Player(int id, string? name, int age, string? position, int teamId)
    {
        Id = id;
        Name = name;
        Age = age;
        Position = position;
        TeamId = teamId;
    }

    public Player() { }

    public override string ToString()
    {
        return $"Player: {Name} - {Position}";
    }
} 