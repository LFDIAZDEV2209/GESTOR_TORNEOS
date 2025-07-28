using Spectre.Console;
using liga.Helpers;
using liga.Models;

namespace liga.Services.TeamServices;

public class AddTeam
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para registrar un nuevo equipo.");
        ScreenPause.Pause();
    }
}

public class AddTechnicalStaff
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Cuerpo Tecnico")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para registrar un nuevo cuerpo tecnico.");
        ScreenPause.Pause();
    }
}

public class AddMedicalStaff
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Cuerpo Medico")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para registrar un nuevo cuerpo medico.");
        ScreenPause.Pause();
    }
}

public class InscribeTournament
{
    public static void Inscribe()
    {
        AnsiConsole.Write(
            new FigletText("Inscribir Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para inscribir un equipo en un torneo.");
        ScreenPause.Pause();
    }
}

public class TransferNotification
{
    public static void Transfer()
    {
        AnsiConsole.Write(
            new FigletText("Notificacion de Transferencia")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para enviar una notificacion de transferencia.");
        ScreenPause.Pause();
    }
}

public class ExitTournament
{
    public static void Exit()
    {
        AnsiConsole.Write(
            new FigletText("Salir del Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para salir de un torneo.");
        ScreenPause.Pause();
    }
}