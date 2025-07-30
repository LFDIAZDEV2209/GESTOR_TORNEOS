using Spectre.Console;
using liga.Helpers;
using liga.Application.Services;
using liga.Application.UI;
using liga.Domain.Factory;
using liga.Infrastructure.Mysql;

namespace liga.Menus;

// Responsabilidad: Mostrar el menu principal
public class MainMenu
{
    private static TournamentUI? _tournamentUI;
    private static TeamUI? _teamUI;

    public static void Show()
    {
        // Configurar la arquitectura hexagonal para torneos
        IDbFactory factory = new TournamentDbFactory();
        var tournamentRepository = factory.CrearTournamentRepository();
        var tournamentService = new TournamentService(tournamentRepository);
        _tournamentUI = new TournamentUI(tournamentService);

        // Configurar la arquitectura hexagonal para equipos
        var teamRepository = factory.CrearTeamRepository();
        var teamService = new TeamService(teamRepository);
        _teamUI = new TeamUI(teamService, tournamentService);

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
                    _tournamentUI?.MostrarMenu();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de equipos...");
                    _teamUI?.MostrarMenu();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de jugadores...");
                    AnsiConsole.MarkupLine("[yellow]Módulo de jugadores en desarrollo...[/]");
                    ScreenPause.Pause();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de transferencias...");
                    AnsiConsole.MarkupLine("[yellow]Módulo de transferencias en desarrollo...[/]");
                    ScreenPause.Pause();
                    break;
                case '4':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu de estadisticas...");
                    AnsiConsole.MarkupLine("[yellow]Módulo de estadísticas en desarrollo...[/]");
                    ScreenPause.Pause();
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