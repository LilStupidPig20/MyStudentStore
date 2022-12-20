using RTF.CQS.Abstractions;

namespace RTF.CQS.Queries;

public class CreateEventQuery : Query<bool>
{
    public string Name { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public string Description { get; set; }
    
    public List<Guid> Organizers { get; set; }
    
    public double Coins { get; set; }
}