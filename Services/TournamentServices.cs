using liga.Models;
using Spectre.Console;
using liga.Helpers;

namespace liga.Services.TournamentServices;

// Responsabilidad: Servicio de torneos
public class AddTournament
{
    public static void Add(List<Tournament> tournaments)
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        string name = ValidateString.AskString("Nombre del torneo: ");
        
        (DateTime startDate, DateTime endDate) = DateInputHelper.AskDateRange(
            "Fecha de inicio (yyyy-mm-dd): ",
            "Fecha de fin (yyyy-mm-dd): "
        );

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

// Responsabilidad: Servicio de busqueda de torneos
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
                int id = ValidateInt.AskInt("ID del torneo:");
                Tournament? tournamentById = tournaments.FirstOrDefault(t => t.Id == id);

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
                string name = ValidateString.AskString("Nombre del torneo:");
                Tournament? tournamentByName = tournaments.FirstOrDefault(t => t.Name == name);

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
                if (tournaments.Count == 0)
                {
                    AnsiConsole.MarkupLine("[bold red]No hay torneos registrados.[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold green]Torneos:[/]");
                    foreach (Tournament tournament in tournaments)
                    {
                        AnsiConsole.MarkupLine($"[bold green]Torneo:[/] {tournament.Name} - {tournament.StartDate:yyyy-MM-dd} - {tournament.EndDate:yyyy-MM-dd}");
                    }
                }
                break;
            case '4':
                ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                Thread.Sleep(900);
                break;
        }
    }
}

// Responsabilidad: Servicio de eliminacion de torneos
public class DeleteTournament
{
    public static void Delete(List<Tournament> tournaments)
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        if (tournaments.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No hay torneos registrados.[/]");
            ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
            Thread.Sleep(900);
            return;
        }

        foreach (Tournament tournament in tournaments)
        {
            AnsiConsole.MarkupLine($"[bold green]Torneo:[/] {tournament.Id} - {tournament.Name}");
        }

        int id = ValidateInt.AskInt("ID del torneo:");
        Tournament? tournamentById = tournaments.FirstOrDefault(t => t.Id == id);

        if (tournamentById != null)
        {
            tournaments.Remove(tournamentById);
            AnsiConsole.MarkupLine($"[bold green]Torneo '{tournamentById.Name}' eliminado exitosamente![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[bold red]Torneo no encontrado.[/]");
        }

        ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
        Thread.Sleep(900);
    }
}

// Responsabilidad: Servicio de actualizacion de torneos
public class UpdateTournament
{
    public static void Update(List<Tournament> tournaments)
    {
        AnsiConsole.Write(
            new FigletText("Actualizar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        if (tournaments.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No hay torneos registrados.[/]");
            ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
            Thread.Sleep(900);
            return;
        }

        foreach (Tournament tournament in tournaments)
        {
            AnsiConsole.MarkupLine($"[bold green]Torneo:[/] {tournament.Id} - {tournament.Name}");
        }

        int id = ValidateInt.AskInt("ID del torneo:");
        Tournament? tournamentById = tournaments.FirstOrDefault(t => t.Id == id);

        if (tournamentById != null)
        {
            string name = ValidateString.AskString("Nombre del torneo:");
            
            (DateTime startDate, DateTime endDate) = DateInputHelper.AskDateRange(
                "Fecha de inicio (yyyy-mm-dd):",
                "Fecha de fin (yyyy-mm-dd):"
            );

            tournamentById.Name = name;
            tournamentById.StartDate = startDate;
            tournamentById.EndDate = endDate;

            AnsiConsole.MarkupLine($"[bold green]Torneo '{tournamentById.Name}' actualizado exitosamente![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[bold red]Torneo no encontrado.[/]");
        }

        ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
        Thread.Sleep(900);
    }
}