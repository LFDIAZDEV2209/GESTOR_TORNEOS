using Spectre.Console;
using System.Threading;

namespace liga.Helpers;

// Responsabilidad: Mostrar mensajes de carga
public static class ConsoleUtils
{
    public static void ShowLoading(string mensaje, int milisegundos = 1200)
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots2)
            .SpinnerStyle(Style.Parse("green"))
            .Start(mensaje, ctx =>
            {
                Thread.Sleep(milisegundos);
            });
    }
}
