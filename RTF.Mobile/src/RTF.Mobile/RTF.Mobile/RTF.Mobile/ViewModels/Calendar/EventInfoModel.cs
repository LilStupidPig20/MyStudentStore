using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTF.Mobile.ViewModels.Calendar
{
    public class EventInfoModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Organizers { get; set; }

        public int Points { get; set; }

        public DateTime StartDate { get; set; }

        public bool CanAddPeople => Math.Abs((StartDate - DateTime.Now).TotalDays) < 3;
    }
}
