namespace liga.Models;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
    public List<Staff> Staffs { get; set; } = new List<Staff>();
    public List<MedicalStaff> MedicalStaffs { get; set; } = new List<MedicalStaff>();

    public Team(int id, string? name, string? city)
    {
        Id = id;
        Name = name;
        City = city;
    }

    public Team() { }

    public override string ToString()
    {
        return $"Team: {Name} - {City}";
    }
}

[[[], [], []], [[], [], []], [[], [], []]], [[[], [], []], [[], [], []], [[], [], []]], [[[], [], []], [[], [], []], [[], [], []]]
