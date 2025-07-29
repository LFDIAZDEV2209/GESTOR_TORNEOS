using Spectre.Console;
using liga.Helpers;
using liga.Models;

namespace liga.Services.TeamServices;

public class AddTeam
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        string name = ValidateString.AskString("Nombre del equipo: ");
        string city = ValidateString.AskString("Ciudad del equipo: ");

        int newId = Program.teams.Count > 0 ? Program.teams.Max(t => t.Id) + 1 : 1;

        Team team = new Team
        {
            Id = newId,
            Name = name,
            City = city
        };

        Program.teams.Add(team);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{team.Name}' de {team.City} creado exitosamente!");
    }
}

public class AddTechnicalStaff
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Cuerpo Tecnico")
            .Centered()
            .Color(Color.Yellow)
        );

        string name = ValidateString.AskString("Nombre del cuerpo tecnico: ");
        string origen = ValidateString.AskString("Origen del cuerpo tecnico: ");
        string email = ValidateString.AskString("Email del cuerpo tecnico: ");
        string role = ValidateString.AskString("Rol del cuerpo tecnico: ");

        int newId = Program.technicalStaff.Count > 0 ? Program.technicalStaff.Max(t => t.Id) + 1 : 1;
        
        TechnicalStaff technicalStaff = new TechnicalStaff
        {
            Id = newId,
            Name = name,
            Origen = origen,
            Email = email,
            Role = role
        };

        Program.technicalStaff.Add(technicalStaff);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Cuerpo tecnico '{technicalStaff.Name}' creado exitosamente!");
    }
}

public class AddMedicalStaff
{
    public static void Add()
    {
        AnsiConsole.Write(
            new FigletText("Nuevo Cuerpo Medico")
            .Centered()
            .Color(Color.Yellow)
        );

        string name = ValidateString.AskString("Nombre del cuerpo medico: ");
        string origen = ValidateString.AskString("Origen del cuerpo medico: ");
        string email = ValidateString.AskString("Email del cuerpo medico: ");
        string speciality = ValidateString.AskString("Especialidad del cuerpo medico: ");

        int newId = Program.medicalStaff.Count > 0 ? Program.medicalStaff.Max(t => t.Id) + 1 : 1;

        MedicalStaff medicalStaff = new MedicalStaff
        {
            Id = newId,
            Name = name,
            Origen = origen,
            Email = email,
            Speciality = speciality
        };

        Program.medicalStaff.Add(medicalStaff);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Cuerpo medico '{medicalStaff.Name}' creado exitosamente!");
    }
}

public class InscribeTournament
{
    public static void Inscribe()
    {
        AnsiConsole.Write(
            new FigletText("Inscribir Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Equipos:");

        foreach (Team team in Program.teams)
        {
            AnsiConsole.MarkupLine($"[bold green]{team.Id} - {team.Name}[/]");
        }

        int teamId = ValidateInt.AskInt("ID del equipo a inscribir: ");
        Team? selectedTeam = Program.teams.FirstOrDefault(t => t.Id == teamId);

        if (selectedTeam == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos:");

        foreach (Tournament tournament in Program.tournaments)
        {
            AnsiConsole.MarkupLine($"[bold green]{tournament.Id} - {tournament.Name}[/]");
        }

        int tournamentId = ValidateInt.AskInt("ID del torneo a inscribir: ");
        Tournament? selectedTournament = Program.tournaments.FirstOrDefault(t => t.Id == tournamentId);

        if (selectedTournament == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
            return;
        }

        selectedTournament.Teams.Add(selectedTeam);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{selectedTeam.Name}' inscrito en el torneo '{selectedTournament.Name}' exitosamente!");
    }
}

public class TransferNotification
{
    public static void Transfer()
    {
        AnsiConsole.Write(
            new FigletText("Notificacion de Transferencia")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Equipos:");

        foreach (Team team in Program.teams)
        {
            AnsiConsole.MarkupLine($"[bold green]{team.Id} - {team.Name} - {team.City}[/]");
        }

        int teamId = ValidateInt.AskInt("ID del equipo a notificar: ");
        Team? selectedTeam = Program.teams.FirstOrDefault(t => t.Id == teamId);

        if (selectedTeam == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        MessageDisplayHelper.ShowInfo("Transferencias del equipo:");

        foreach (Transfer transfer in Program.transfers)
        {
            if (transfer.FromTeam?.Id == teamId || transfer.ToTeam?.Id == teamId)
            {
                AnsiConsole.MarkupLine($"[bold green]{transfer.Id} - {transfer.Player?.Name} - {transfer.FromTeam?.Name} -> {transfer.ToTeam?.Name}[/]");
            }
        }

        UserExperienceHelper.ShowSuccessAndRedirect($"Redireccionando al menu principal...");
    }
}

public class ExitTournament
{
    public static void Exit()
    {
        AnsiConsole.Write(
            new FigletText("Salir del Torneo")
            .Centered()
            .Color(Color.Yellow)
        );

        MessageDisplayHelper.ShowInfo("Equipos:");

        foreach (Team team in Program.teams)
        {
            AnsiConsole.MarkupLine($"[bold green]{team.Id} - {team.Name} - {team.City}[/]");
        }

        int teamId = ValidateInt.AskInt("ID del equipo a salir: ");
        Team? selectedTeam = Program.teams.FirstOrDefault(t => t.Id == teamId);

        if (selectedTeam == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Equipo no encontrado.");
            return;
        }

        MessageDisplayHelper.ShowInfo("Torneos donde participa el equipo:");

        foreach (Tournament tournament in Program.tournaments)
        {
            if (tournament.Teams.Contains(selectedTeam))
            {
                AnsiConsole.MarkupLine($"[bold green]{tournament.Id} - {tournament.Name}[/]");
            }
        }

        int tournamentId = ValidateInt.AskInt("ID del torneo a salir: ");
        Tournament? selectedTournament = Program.tournaments.FirstOrDefault(t => t.Id == tournamentId);

        if (selectedTournament == null)
        {
            UserExperienceHelper.ShowErrorAndRedirect("Torneo no encontrado.");
            return;
        }

        selectedTournament.Teams.Remove(selectedTeam);

        UserExperienceHelper.ShowSuccessAndRedirect($"¡Equipo '{selectedTeam.Name}' salido del torneo '{selectedTournament.Name}' exitosamente!");
    }
}