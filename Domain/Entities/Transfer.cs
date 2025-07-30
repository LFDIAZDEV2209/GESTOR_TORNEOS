namespace liga.Domain.Entities;

// Responsabilidad: Entidad de transferencia
public class Transfer
{
    public int Id { get; set; }
    public string? PlayerName { get; set; }
    public string? TransferType { get; set; } // "Compra" o "Préstamo"
    public int FromTeamId { get; set; }
    public int ToTeamId { get; set; }
    public DateTime TransferDate { get; set; }

    public Transfer(int id, string? playerName, string? transferType, int fromTeamId, int toTeamId, DateTime transferDate)
    {
        Id = id;
        PlayerName = playerName;
        TransferType = transferType;
        FromTeamId = fromTeamId;
        ToTeamId = toTeamId;
        TransferDate = transferDate;
    }

    public Transfer() { }

    public override string ToString()
    {
        return $"Transfer: {PlayerName} - {TransferType}";
    }
} 