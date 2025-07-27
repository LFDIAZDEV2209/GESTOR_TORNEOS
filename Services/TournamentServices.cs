using liga.Models;
using Spectre.Console;
using liga.Helpers;

namespace liga.Services.TournamentServices;

public class AddTournament
{
    public static void Add(List<Tournament> tournaments)
    {
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
    }
}

public class FindTournament
{
    public static void Find(List<Tournament> tournaments)
    {
        AnsiConsole.Write(
            new FigletText("Buscar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        string typeFind = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold green]¿Cómo desea buscar el torneo?[/]")
            .AddChoices(new[]
            {
                "1. Por ID",
                "2. Por Nombre",
                "3. Mostrar todos",
                "4. Regresar al Menu Principal"
            })
        );

        switch (typeFind[0])
        {
            case '1':
                int id = ValidateInt.AskInt("ID del torneo");
                Tournament tournamentById = tournaments.FirstOrDefault(t => t.Id == id);

                if (tournamentById != null)
                {
                    AnsiConsole.MarkupLine($"[bold green]Torneo encontrado:[/] {tournamentById}");
                    
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Torneo no encontrado.[/]");
                }
                break;
            case '2':
                string name = ValidateString.AskString("Nombre del torneo");
                Tournament tournamentByName = tournaments.FirstOrDefault(t => t.Name == name);

                if (tournamentByName != null)
                {
                    AnsiConsole.MarkupLine($"[bold green]Torneo encontrado:[/] {tournamentByName}");
                    
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Torneo no encontrado.[/]");
                }
                break;
            case '3':
                AnsiConsole.MarkupLine("[bold green]Torneos:[/]");
                foreach (Tournament tournament in tournaments)
                {
                    AnsiConsole.MarkupLine($"[bold green]Torneo:[/] {tournament.Name} - {tournament.StartDate} - {tournament.EndDate}");
                }
                break;
            case '4':
                ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                Thread.Sleep(900);
                break;
        }
    }
}