namespace liga.Models;

public class Person 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Origen { get; set; }
    public string? Email { get; set; }

    public Person(int id, string? name, string? origen, string? email)
    {
        Id = id;
        Name = name;
        Origen = origen;
        Email = email;
    }

    public Person() {}
}