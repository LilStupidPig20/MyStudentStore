using System;
using System.Collections;
using System.Collections.Generic;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class EventDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Desciption { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public EventType EventType { get; set; }

        public IEnumerable<string> OrganizersNames { get; set; }

        public int Points { get; set; }

        public EventDto()
        {
        }

        public EventDto(Guid id, string title, int points, EventType eventType)
        {
            Name = title;
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
