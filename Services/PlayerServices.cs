using Spectre.Console;
using liga.Helpers;
using liga.Models;

namespace liga.Services.PlayerServices;

public class AddPlayer
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para registrar un nuevo jugador.");
        ScreenPause.Pause();
    }
}

public class FindPlayer
{
    public static void Find()
    {
        AnsiConsole.Write(
            new FigletText("Buscar Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para buscar un jugador.");
        ScreenPause.Pause();
    }
}

public class EditPlayer
{
    public static void Edit()
    {
        AnsiConsole.Write(
            new FigletText("Editar Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para editar un jugador.");
        ScreenPause.Pause();
    }
}

public class DeletePlayer
{
    public static void Delete()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para eliminar un jugador.");
        ScreenPause.Pause();
    }
}