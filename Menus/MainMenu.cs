using Spectre.Console;
using liga.Helpers;

namespace liga.Menus;

// Responsabilidad: Mostrar el menu principal
public class MainMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestor de Torneos")
                .Centered()
                .Color(Color.Red)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Crear Torneo",
                    "1. Registro Equipos",
                    "2. Registro Jugadores",
                    "3. Transferencias (Compra, Préstamo)",
                    "4. Estadísticas",
                    "5. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de torneos...");
                    TournamentMenu.Show();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de equipos...");
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de jugadores...");
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de transferencias...");
                    break;
                case '4':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de estadisticas...");
                    break;
                case '5':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Saliendo...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    ScreenPause.Pause();
                    break;
            }
        }
    }
}