using liga.Menus;
using liga.Models;

namespace liga;

class Program
{
    public static List<Tournament> tournaments = new List<Tournament>();

    static void Main(string[] args)
    {
        MainMenu.Show();
    }
}