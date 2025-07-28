using Spectre.Console;
using liga.Helpers;
using liga.Models;

namespace liga.Services.TransferServices;

public class PayPlayer
{
    public static void Pay()
    {
        AnsiConsole.Write(
            new FigletText("Comprar Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para comprar un jugador.");
        ScreenPause.Pause();
    }
}

public class LoanPlayer
{
    public static void Loan()
    {
        AnsiConsole.Write(
            new FigletText("Prestar Jugador")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Aqui ira la logica para prestar un jugador.");
        ScreenPause.Pause();
    }
}