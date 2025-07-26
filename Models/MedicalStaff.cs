namespace liga.Models;

public class MedicalStaff : Person
{
    public string? Speciality { get; set; }

    public MedicalStaff(int id, string? name, string? origen, string? email, string? speciality) : base(id, name, origen, email)
    {
        Id = id;
        Name = name;
        Origen = origen;
        Email = email;
        Speciality = speciality;
    }

    public MedicalStaff() { }

    public override string ToString()
    {
        return $"MedicalStaff: {Name} - {Speciality}";
    }
}