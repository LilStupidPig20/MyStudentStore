using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using System.Collections.ObjectModel;

namespace RTF.Mobile.ViewModels.Calendar
{
    public class CalendarModel : EditableModel
    {
        public ObservableCollection<EventShortInfoDto> Events { get; set; }
    }
}
