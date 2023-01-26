using System;
using Xamarin.Forms;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class EventShortInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public EventType EventType { get; set; }

        public bool IsAllDay => false;

        public Color Color => EventType == EventType.Social ? Color.FromHex("#B7FFBA") : Color.FromHex("#9FA3FF");
    }
}
