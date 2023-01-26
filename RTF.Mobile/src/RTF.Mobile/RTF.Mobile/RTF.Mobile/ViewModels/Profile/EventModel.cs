using RTF.Mobile.Infrastructure.Abstractions.Models;

namespace RTF.Mobile.ViewModels.Profile
{
    public class EventModel
    {
        public string Title { get; }

        public int Points { get; }

        public EventType EventType { get; }

        public EventModel(string title, int points, EventType eventType)
        {
            Title = title;
            Points = points;
            EventType = eventType;
        }
    }
}
