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

// Responsabilidad: Manejar la experiencia de usuario
public static class UserExperienceHelper
{
    public static void ShowSuccessAndRedirect(string mensaje, string redirectMessage = "Redireccionando al menu principal...")
    {
        MessageDisplayHelper.ShowSuccess(mensaje);
        ScreenPause.Pause();
        ConsoleUtils.ShowLoading(redirectMessage, 900);
    }

    public static void ShowErrorAndRedirect(string mensaje, string redirectMessage = "Redireccionando al menu principal...")
    {
        MessageDisplayHelper.ShowError(mensaje);
        ScreenPause.Pause();
        ConsoleUtils.ShowLoading(redirectMessage, 900);
    }

    public static void ShowEmptyListAndRedirect(string mensaje = "No hay torneos registrados.", string redirectMessage = "Redireccionando al menu principal...")
    {
        MessageDisplayHelper.ShowError(mensaje);
        ScreenPause.Pause();
        ConsoleUtils.ShowLoading(redirectMessage, 900);
    }

    public static void ShowInfoAndRedirect(string mensaje, string redirectMessage = "Redireccionando al menu principal...")
    {
        MessageDisplayHelper.ShowInfo(mensaje);
        ScreenPause.Pause();
        ConsoleUtils.ShowLoading(redirectMessage, 900);
    }
}

// Responsabilidad: Mostrar mensajes con diferentes estilos
public static class MessageDisplayHelper
{
    public static void ShowSuccess(string mensaje)
    {
        AnsiConsole.MarkupLine($"[bold green]{mensaje}[/]");
    }

    public static void ShowError(string mensaje)
    {
        AnsiConsole.MarkupLine($"[bold red]{mensaje}[/]");
    }

    public static void ShowInfo(string mensaje)
    {
        AnsiConsole.MarkupLine($"[bold blue]{mensaje}[/]");
    }

    public static void ShowWarning(string mensaje)
    {
        AnsiConsole.MarkupLine($"[bold yellow]{mensaje}[/]");
    }
}
