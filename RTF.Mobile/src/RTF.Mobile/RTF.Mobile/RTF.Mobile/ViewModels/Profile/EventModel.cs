using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Runtime.CompilerServices;

namespace RTF.Mobile.ViewModels.Profile
{
    public class EventModel
    {
        public string Title { get; }

        public int Points { get; }

        public bool IsSocial { get; }

        public EventModel(string title, int points, EventType eventType)
        {
            Title = title;
            Points = points;
            IsSocial = eventType == EventType.Social;
        }
    }
}
