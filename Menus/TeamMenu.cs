using Spectre.Console;
using liga.Helpers;
using liga.Services.TeamServices;
using liga.Models;

namespace liga.Menus;

public class TeamMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Registrar Equipo",
                    "1. Registrar Cuerpo Tecnico",
                    "2. Registrar Cuerpo Medico",
                    "3. Inscribir Torneo",
                    "4. Notificacion de Transferencia",
                    "5. Salir del Torneo",
                    "6. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando el formulario de nuevo equipo...");
                    AddTeam.Add();
                    break;
                case '1':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando Equipos...");
                    AddTechnicalStaff.Add();
                    break;
                case '2':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando Equipos...");
                    AddMedicalStaff.Add();
                    break;
                case '3':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando Equipos...");
                    InscribeTournament.Inscribe();
                    break;
                case '4':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Preparando la notificacion de transferencia...");
                    TransferNotification.Transfer();
                    break;
                case '5':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Cargando Equipos...");
                    ExitTournament.Exit();
                    break;
                case '6':
                    Console.Clear();
                    ConsoleUtils.ShowLoading("Redireccionando al menu principal...");
                    return;
                default:
                    Console.Clear();
                    UserExperienceHelper.ShowErrorAndRedirect("Opción no válida.", "Intentelo nuevamente.");
                    break;
            }
        }
    }
}