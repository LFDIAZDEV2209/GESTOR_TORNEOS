/*
    Autor: Luis Felipe Diaz
    Fecha: 2025-07-25
    Descripción: Programa para gestionar torneos de fútbol
*/

using liga.Menus;
using liga.Domain.Entities;

namespace liga;

// Responsabilidad: Punto de entrada del programa
class Program
{
    public static List<Tournament> tournaments = new List<Tournament>();

    public static List<Team> teams = new List<Team>();
    public static List<Player> players = new List<Player>();
    public static List<TechnicalStaff> technicalStaff = new List<TechnicalStaff>();
    public static List<MedicalStaff> medicalStaff = new List<MedicalStaff>();
    public static List<Transfer> transfers = new List<Transfer>();

    static void Main(string[] args)
    {
        MainMenu.Show();
    }
}