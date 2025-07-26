using Spectre.Console;
using System.Threading;

namespace liga.Menus;

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
                    ShowLoading("Creando Torneo...");
                    break;
                case '1':
                    ShowLoading("Registro de Equipos...");
                    break;
                case '2':
                    ShowLoading("Registro de Jugadores...");
                    break;
                case '3':
                    ShowLoading("Transferencias (Compra, Préstamo)...");
                    break;
                case '4':
                    ShowLoading("Estadísticas...");
                    break;
                case '5':
                    ShowLoading("Saliendo...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }

    private static void ShowLoading(string mensaje)
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots2)
            .SpinnerStyle(Style.Parse("green"))
            .Start(mensaje, ctx =>
            {
                Thread.Sleep(1200);
            });
    }
}