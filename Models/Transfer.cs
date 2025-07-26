namespace liga.Models;

public class Transfer
{
    public int Id { get; set; }
    public Player? Player { get; set; }
    public Team? FromTeam { get; set; }
    public Team? ToTeam { get; set; }
    public decimal Amount { get; set; }
    public string? Type { get; set; }
    public DateTime Date { get; set; }

    public Transfer(int id, Player player, Team fromTeam, Team toTeam, decimal amount, string type, DateTime date)
    {
        Id = id;
        Player = player;
        FromTeam = fromTeam;
        ToTeam = toTeam;
        Amount = amount;
        Type = type;
        Date = date;
    }

    public Transfer() { }

    public override string ToString()
    {
        return $"Transfer: {Player.Name} - {FromTeam.Name} - {ToTeam.Name} - {Amount} - {Type} - {Date}";
    }
}