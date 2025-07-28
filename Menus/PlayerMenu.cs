using Spectre.Console;
using liga.Helpers;
using liga.Services.PlayerServices;

namespace liga.Menus;

public class PlayerMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Jugadores")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Registrar Jugador",
                    "1. Buscar Jugador",
                    "2. Editar Jugador",
                    "3. Eliminar Jugador",
                    "4. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando el formulario de nuevo jugador...");
                    AddPlayer.Add();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Iniciando el buscador de jugadores...");
                    FindPlayer.Find();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando jugadores...");
                    EditPlayer.Edit();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando jugadores...");
                    DeletePlayer.Delete();
                    break;
                case '4':
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