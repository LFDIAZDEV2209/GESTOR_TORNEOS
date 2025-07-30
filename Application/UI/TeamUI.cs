using Spectre.Console;
using liga.Application.Services;
using liga.Domain.Entities;
using liga.Helpers;

namespace liga.Application.UI;

// Responsabilidad: UI para gestión de equipos
public class TeamUI
{
    private readonly TeamService _teamService;
    private readonly TournamentService _tournamentService;

    public TeamUI(TeamService teamService, TournamentService tournamentService)
    {
        _teamService = teamService;
        _tournamentService = tournamentService;
    }

    public void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Registro de Equipos")
                .Centered()
                .Color(Color.Green)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "1.1. Registrar Equipo",
                    "1.2. Registrar Cuerpo Técnico",
                    "1.3. Registrar Cuerpo Médico",
                    "1.4. Inscripción Torneo",
                    "1.5. Notificación de Transferencia",
                    "1.6. Salir de Torneo",
                    "1.7. Regresar al Menú Principal"
                })
            );

            switch (selection.Substring(0, 3))
            {
                case "1.1":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando formulario de nuevo equipo...");
                    RegistrarEquipo();
                    break;
                case "1.2":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando formulario de cuerpo técnico...");
                    RegistrarCuerpoTecnico();
                    break;
                case "1.3":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando formulario de cuerpo médico...");
                    RegistrarCuerpoMedico();
                    break;
                case "1.4":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando inscripción a torneo...");
                    InscripcionTorneo();
                    break;
                case "1.5":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando notificación de transferencia...");
                    NotificacionTransferencia();
                    break;
                case "1.6":
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando salida de torneo...");
                    SalirDeTorneo();
                    break;
                case "1.7":
                    ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                    return;
                default:
                    Console.Clear();
                    UserExperienceHelper.ShowErrorAndRedirect("Opción no válida.", "Inténtelo nuevamente.");
                    break;
            }
        }
    }

    private void RegistrarEquipo()
    {
        AnsiConsole.Write(
            new FigletText("Registrar Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        string nombre = ValidateString.AskString("Nombre del equipo: ");
        string ciudad = ValidateString.AskString("Ciudad del equipo: ");

        _teamService.CrearEquipo(nombre, ciudad);
        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{nombre}' registrado exitosamente!");
    }

    private void RegistrarCuerpoTecnico()
    {
        AnsiConsole.Write(
            new FigletText("Registrar Cuerpo Técnico")
            .Centered()
            .Color(Color.Blue)
        );

        var equipos = _teamService.ObtenerTodos();

        if (equipos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Equipos disponibles:");
        foreach (Team equipo in equipos)
        {
            AnsiConsole.MarkupLine($"[bold green]{equipo.Id} - {equipo.Name} ({equipo.City})[/]");
        }

        int idEquipo = ValidateInt.AskInt("ID del equipo: ");
        Team? equipoSeleccionado = equipos.FirstOrDefault(e => e.Id == idEquipo);

        if (equipoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        string nombre = ValidateString.AskString("Nombre del técnico: ");
        string cargo = ValidateString.AskString("Cargo del técnico: ");

        // TODO: Implementar lógica para registrar cuerpo técnico
        UserExperienceHelper.ShowSuccessAndRedirect($"¡Cuerpo técnico registrado para '{equipoSeleccionado.Name}'!");
    }

    private void RegistrarCuerpoMedico()
    {
        AnsiConsole.Write(
            new FigletText("Registrar Cuerpo Médico")
            .Centered()
            .Color(Color.Red)
        );

        var equipos = _teamService.ObtenerTodos();

        if (equipos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Equipos disponibles:");
        foreach (Team equipo in equipos)
        {
            AnsiConsole.MarkupLine($"[bold green]{equipo.Id} - {equipo.Name} ({equipo.City})[/]");
        }

        int idEquipo = ValidateInt.AskInt("ID del equipo: ");
        Team? equipoSeleccionado = equipos.FirstOrDefault(e => e.Id == idEquipo);

        if (equipoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        string nombre = ValidateString.AskString("Nombre del médico: ");
        string especialidad = ValidateString.AskString("Especialidad del médico: ");

        // TODO: Implementar lógica para registrar cuerpo médico
        UserExperienceHelper.ShowSuccessAndRedirect($"¡Cuerpo médico registrado para '{equipoSeleccionado.Name}'!");
    }

    private void InscripcionTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Inscripción a Torneo")
            .Centered()
            .Color(Color.Blue)
        );

        var torneos = _tournamentService.ObtenerTodos();

        if (torneos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        var equipos = _teamService.ObtenerTodos();

        if (equipos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Equipos disponibles:");
        foreach (Team equipo in equipos)
        {
            AnsiConsole.MarkupLine($"[bold green]{equipo.Id} - {equipo.Name} ({equipo.City})[/]");
        }

        int idEquipo = ValidateInt.AskInt("ID del equipo a inscribir: ");
        Team? equipoSeleccionado = equipos.FirstOrDefault(e => e.Id == idEquipo);

        if (equipoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos disponibles:");
        foreach (Tournament torneo in torneos)
        {
            AnsiConsole.MarkupLine($"[bold green]{torneo.Id} - {torneo.Name} ({torneo.StartDate:dd/MM/yyyy} - {torneo.EndDate:dd/MM/yyyy})[/]");
        }

        int idTorneo = ValidateInt.AskInt("ID del torneo: ");
        Tournament? torneoSeleccionado = torneos.FirstOrDefault(t => t.Id == idTorneo);

        if (torneoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
            return;
        }

        _teamService.InscribirTorneo(idEquipo, idTorneo);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{equipoSeleccionado.Name}' inscrito al torneo '{torneoSeleccionado.Name}'!");
    }

    private void NotificacionTransferencia()
    {
        AnsiConsole.Write(
            new FigletText("Notificación de Transferencia")
            .Centered()
            .Color(Color.Blue)
        );

        var equipos = _teamService.ObtenerTodos();

        if (equipos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Equipos disponibles:");
        foreach (Team equipo in equipos)
        {
            AnsiConsole.MarkupLine($"[bold green]{equipo.Id} - {equipo.Name} ({equipo.City})[/]");
        }

        int idEquipo = ValidateInt.AskInt("ID del equipo: ");
        Team? equipoSeleccionado = equipos.FirstOrDefault(e => e.Id == idEquipo);

        if (equipoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        string jugador = ValidateString.AskString("Nombre del jugador: ");
        string tipoTransferencia = ValidateString.AskString("Tipo de transferencia (Compra/Préstamo): ");

        // TODO: Implementar lógica para notificación de transferencia
        UserExperienceHelper.ShowSuccessAndRedirect($"¡Notificación de transferencia registrada para '{equipoSeleccionado.Name}'!");
    }

    private void SalirDeTorneo()
    {
        AnsiConsole.Write(
            new FigletText("Salir de Torneo")
            .Centered()
            .Color(Color.Orange1)
        );

        var torneos = _tournamentService.ObtenerTodos();

        var equipos = _teamService.ObtenerTodos();

        if (equipos.Count == 0)
        {
            UserExperienceHelper.ShowEmptyListAndRedirect();
            return;
        }

        MessageDisplayHelper.ShowInfo("Equipos disponibles:");
        foreach (Team equipo in equipos)
        {
            AnsiConsole.MarkupLine($"[bold green]{equipo.Id} - {equipo.Name} ({equipo.City})[/]");
        }

        int idEquipo = ValidateInt.AskInt("ID del equipo: ");
        Team? equipoSeleccionado = equipos.FirstOrDefault(e => e.Id == idEquipo);

        if (equipoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        // Obtener el equipo actualizado del repositorio para ver sus torneos
        var equipoActualizado = _teamService.ObtenerPorId(idEquipo);
        if (equipoActualizado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Error al obtener el equipo.");
            return;
        }

        if (equipoActualizado.Tournaments.Count == 0)
        {
            UserExperienceHelper.ShowErrorAndRedirect("El equipo no está inscrito en ningún torneo.");
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos en los que está inscrito:");
        foreach (Tournament torneo in torneos)
        {
            if (equipoActualizado.Tournaments.Contains(torneo.Id))
            {
                AnsiConsole.MarkupLine($"[bold green]{torneo.Id} - {torneo.Name} ({torneo.StartDate:dd/MM/yyyy} - {torneo.EndDate:dd/MM/yyyy})[/]");
            }
        }

        int idTorneo = ValidateInt.AskInt("ID del torneo: ");
        Tournament? torneoSeleccionado = torneos.FirstOrDefault(t => t.Id == idTorneo);

        if (torneoSeleccionado == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
            return;
        }

        if (!equipoActualizado.Tournaments.Contains(idTorneo))
        {
            UserExperienceHelper.ShowErrorAndRedirect("El equipo no está inscrito en ese torneo.");
            return;
        }

        _teamService.SalirTorneo(idEquipo, idTorneo);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{equipoSeleccionado.Name}' ha salido del torneo '{torneoSeleccionado.Name}'!");
    }
} 