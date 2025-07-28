using Spectre.Console;
using liga.Helpers;
using liga.Services.StatsServices;

namespace liga.Menus;

public class StatsMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Estadisticas")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Jugador con mas Asistencias de Torneo",
                    "1. Equipo con mas Goles en Torneo",
                    "2. Jugadores mas caros por Equipo",
                    "3. Jugadores menor al promedio de edad por Equipo",
                    "4. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando estadisticas...");
                    BestAssist.Show();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando estadisticas...");
                    BestGoal.Show();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando estadisticas...");
                    BestPrice.Show();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando estadisticas...");
                    YoungerAverage.Show();
                    break;
                case '4':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                    return;
                default:
                    Console.Clear();
                    ConsoleUtils.ShowErrorAndRedirect("Opción no válida.", "Intentelo nuevamente.");
                    break;
            }
        }
    }
}