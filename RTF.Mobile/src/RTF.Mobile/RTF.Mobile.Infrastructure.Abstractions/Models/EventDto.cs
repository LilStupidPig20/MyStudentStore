namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class EventDto
    {
        public string Title { get; }

        public int Points { get; }

        public EventType EventType { get; }

        public EventDto(string title, int points, EventType eventType)
        {
            Title = title;
            Points = points;
            EventType = eventType;
        }
    }
   
    public enum EventType 
    {
        Educational,
        Social,
    }
}
