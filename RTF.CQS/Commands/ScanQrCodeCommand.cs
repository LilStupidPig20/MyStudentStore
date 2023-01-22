using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class ScanQrCodeCommand : Command
{
    public Guid EventId { get; set; }
    
    public Guid UserQrId { get; set; }
}