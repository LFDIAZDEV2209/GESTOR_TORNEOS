using Spectre.Console;
using liga.Models;
using System.Threading;
using liga.Helpers;
using liga.Services.TournamentServices;

namespace liga.Menus;

public class TournamentMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Torneos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                      "0. Agregar Torneo",
                      "1. Buscar Torneo",
                      "2. Eliminar Torneo",
                      "3. Actualizar Torneo",
                      "4. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando el formulario de nuevo torneo...");
                    AddTournament.Add(Program.tournaments);
                    Console.ReadKey();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Iniciando el buscador de torneos...");
                    FindTournament.Find(Program.tournaments);
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando torneos...");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando torneos...");
                    Console.ReadKey();
                    break;
                case '4':
                    ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    Console.ReadKey();
                    break;
            }
        }
    }
}