using System;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class EventDto
    {
        public Guid Id { get; }

        public string Title { get; }

        public int Points { get; }

        public EventType EventType { get; }

        public EventDto(Guid id, string title, int points, EventType eventType)
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
