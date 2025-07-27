using Spectre.Console;
using System.Globalization;

namespace liga.Helpers;

public class ValidateDate
{
    public static DateTime AskDate(string prompt)
    {
        while (true)
        {
            string input = AnsiConsole.Ask<string>($"[blue]{prompt}[/]");
            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                return fecha;

            AnsiConsole.MarkupLine("[red]Formato inválido. Debe ser YYYY-MM-DD. Intente de nuevo.[/]");
        }
    }
}

public class ValidateString
{
    public static string AskString(string prompt)
    {
        while (true)
        {
            string input = AnsiConsole.Ask<string>($"[blue]{prompt}[/]");
            if (!string.IsNullOrEmpty(input))
                return input;

            AnsiConsole.MarkupLine("[red]El nombre no puede estar vacío. Intente de nuevo.[/]");
        }
    }
}

public class ValidateInt
{
    public static int AskInt(string prompt)
    {
        while (true)
        {
            string input = AnsiConsole.Ask<string>($"[blue]{prompt}[/]");
            if (int.TryParse(input, out int number))
                return number;

            AnsiConsole.MarkupLine("[red]El valor ingresado no es un número entero. Intente de nuevo.[/]");
        }
    }
}