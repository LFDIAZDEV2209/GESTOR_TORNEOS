using liga.Models;
using Spectre.Console;
using liga.Helpers;

namespace liga.Services.TournamentServices;

public class AddTournament
{
    public static void Add(List<Tournament> tournaments)
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Nuevo Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        string name = ValidateString.AskString("Nombre del torneo");
        DateTime startDate = ValidateDate.AskDate("Fecha de inicio (yyyy-mm-dd)");
        DateTime endDate = ValidateDate.AskDate("Fecha de fin (yyyy-mm-dd)");

        int newId = tournaments.Count > 0 ? tournaments.Max(t => t.Id) + 1 : 1;

        Tournament tournament = new Tournament
        {
            Id = newId,
            Name = name,
            StartDate = startDate,
            EndDate = endDate
        };

        tournaments.Add(tournament);

        ConsoleUtils.ShowLoading("Guardando torneo...");
        AnsiConsole.MarkupLine($"[bold green]¡Torneo '{tournament.Name}' creado exitosamente![/]");
        Thread.Sleep(900);

        Console.ReadKey();
    }
}