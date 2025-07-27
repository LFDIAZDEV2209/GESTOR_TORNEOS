using Spectre.Console;
using System.Globalization;

namespace liga.Helpers;

// Responsabilidad: Validar formato de fechas
public class ValidateDate
{
    public static DateTime AskDate(string prompt)
    {
        while (true)
        {
            string input = AnsiConsole.Ask<string>($"[blue]{prompt}[/]");
            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;

            AnsiConsole.MarkupLine("[red]Formato inválido. Debe ser YYYY-MM-DD. Intente de nuevo.[/]");
        }
    }
}

// Responsabilidad: Validar reglas de negocio para rangos de fechas
public class DateRangeValidator
{
    public static bool IsValidStartDate(DateTime startDate)
    {
        if (startDate < DateTime.Today)
        {
            AnsiConsole.MarkupLine("[red]La fecha de inicio no puede ser menor a la fecha actual. Intente de nuevo.[/]");
            return false;
        }
        return true;
    }

    public static bool IsValidEndDate(DateTime endDate, DateTime startDate)
    {
        if (endDate < startDate)
        {
            AnsiConsole.MarkupLine("[red]La fecha de fin no puede ser anterior a la fecha de inicio. Intente de nuevo.[/]");
            return false;
        }
        return true;
    }

    public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
    {
        return IsValidStartDate(startDate) && IsValidEndDate(endDate, startDate);
    }
}

// Responsabilidad: Manejar la entrada de rangos de fechas
public class DateInputHelper
{
    public static (DateTime startDate, DateTime endDate) AskDateRange(string startPrompt, string endPrompt)
    {
        DateTime startDate, endDate;

        // Solicitar fecha de inicio
        do
        {
            startDate = ValidateDate.AskDate(startPrompt);
        } while (!DateRangeValidator.IsValidStartDate(startDate));

        // Solicitar fecha de fin
        do
        {
            endDate = ValidateDate.AskDate(endPrompt);
        } while (!DateRangeValidator.IsValidEndDate(endDate, startDate));

        return (startDate, endDate);
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