using liga.Application.Services;
using liga.Domain.Entities;
using Spectre.Console;
using liga.Helpers;

namespace liga.Application.UI;

// Responsabilidad: UI para gestión de torneos
public class TournamentUI
{
    private readonly TournamentService _tournamentService;

    public TournamentUI(TournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    public void MostrarMenu()
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
                    AgregarTorneo();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Iniciando el buscador de torneos...");
                    BuscarTorneo();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando torneos...");
                    EliminarTorneo();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando torneos...");
                    ActualizarTorneo();
                    break;
                case '4':
                    ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }

    private void AgregarTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Torneo")
            .Centered()
            .Color(Color.Yellow)
        );
        
        string nombre = ValidateString.AskString("Nombre del torneo: ");
        
        (DateTime fechaInicio, DateTime fechaFin) = DateInputHelper.AskDateRange(
            "Fecha de inicio (yyyy-mm-dd): ",
            "Fecha de fin (yyyy-mm-dd): "
        );

        _tournamentService.CrearTorneo(nombre, fechaInicio, fechaFin);
        UserExperienceHelper.ShowSuccessAndRedirect($"¡Torneo '{nombre}' creado exitosamente!");
    }

    private void BuscarTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Buscar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        var torneos = _tournamentService.ObtenerTodos();
        
        MessageDisplayHelper.ShowInfo("Torneos:");
        foreach (Tournament tournament in torneos)
        {
            AnsiConsole.MarkupLine($"[bold green]{tournament.Name} - {tournament.StartDate:yyyy-MM-dd} - {tournament.EndDate:yyyy-MM-dd}[/]");
        }
        UserExperienceHelper.ShowInfoAndRedirect("Torneos mostrados.");
    }

    private void EliminarTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        var torneos = _tournamentService.ObtenerTodos();

        if (torneos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos:");
        foreach (Tournament tournament in torneos)
        {
            AnsiConsole.MarkupLine($"[bold green]{tournament.Id} - {tournament.Name}[/]");
        }

        int id = ValidateInt.AskInt("ID del torneo:");
        Tournament? tournamentById = torneos.FirstOrDefault(t => t.Id == id);

        if (tournamentById != null)
        {
            _tournamentService.EliminarTorneo(id);
            UserExperienceHelper.ShowSuccessAndRedirect($"¡Torneo '{tournamentById.Name}' eliminado exitosamente!");
        }
        else
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
        }
    }

    private void ActualizarTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Actualizar Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        var torneos = _tournamentService.ObtenerTodos();
        
        if (torneos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos:");
        foreach (Tournament tournament in torneos)
        {
            AnsiConsole.MarkupLine($"[bold green]{tournament.Id} - {tournament.Name}[/]");
        }

        int id = ValidateInt.AskInt("ID del torneo:");
        Tournament? tournamentById = torneos.FirstOrDefault(t => t.Id == id);

        if (tournamentById != null)
        {
            string nombre = ValidateString.AskString("Nuevo nombre:");
            (DateTime fechaInicio, DateTime fechaFin) = DateInputHelper.AskDateRange(
                "Nueva fecha de inicio (yyyy-mm-dd): ",
                "Nueva fecha de fin (yyyy-mm-dd): "
            );

            tournamentById.Name = nombre;
            tournamentById.StartDate = fechaInicio;
            tournamentById.EndDate = fechaFin;

            _tournamentService.ActualizarTorneo(id, nombre, fechaInicio, fechaFin);
            UserExperienceHelper.ShowSuccessAndRedirect($"¡Torneo '{tournamentById.Name}' actualizado exitosamente!");
        }
        else
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
        }
    }
} 