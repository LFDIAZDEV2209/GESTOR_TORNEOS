using Spectre.Console;
using liga.Helpers;
using liga.Services.TransferServices;

namespace liga.Menus;

public class TransferMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Transferencias")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Comprar Jugador",
                    "1. Prestar Jugador",
                    "2. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando jugadores disponibles...");
                    PayPlayer.Pay();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando jugadores disponibles...");
                    LoanPlayer.Loan();
                    break;
                case '2':
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