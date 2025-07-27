using Spectre.Console;

namespace liga.Helpers;

// Responsabilidad: Pausar la pantalla
public class ScreenPause
{
    public static void Pause()
    {
        AnsiConsole.Markup("[bold green]Presione Enter para continuar...[/]");
        Console.ReadLine();
    }
}