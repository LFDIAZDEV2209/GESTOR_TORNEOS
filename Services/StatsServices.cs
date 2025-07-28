using Spectre.Console;
using liga.Helpers;
using liga.Models;

namespace liga.Services.StatsServices;

public class BestAssist
{
    public static void Show()
    {
        AnsiConsole.Write(
            new FigletText("Jugador con mas Asistencias de Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para obtener el jugador con mas asistencias de torneo.");
        ScreenPause.Pause();
    }
}

public class BestGoal
{
    public static void Show()
    {
        AnsiConsole.Write(
            new FigletText("Equipo con mas Goles en Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para obtener el equipo con mas goles en torneo.");
        ScreenPause.Pause();
    }
}

public class BestPrice
{
    public static void Show()
    {
        AnsiConsole.Write(
            new FigletText("Jugadores mas caros por Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para obtener los jugadores mas caros por equipo.");
        ScreenPause.Pause();
    }
}

public class YoungerAverage
{
    public static void Show()
    {
        AnsiConsole.Write(
            new FigletText("Jugadores menor al promedio de edad por Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para obtener los jugadores menor al promedio de edad por equipo.");
        ScreenPause.Pause();
    }
}