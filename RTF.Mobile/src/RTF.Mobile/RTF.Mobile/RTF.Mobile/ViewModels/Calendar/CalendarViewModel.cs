using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RTF.Mobile.Utils.PageInt;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Runtime.InteropServices;
using Syncfusion.SfSchedule.XForms;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.Views.Calendar;

namespace RTF.Mobile.ViewModels.Calendar
{
    public class CalendarViewModel : BaseViewModel, IShellViewModel
    {
        private IApiService apiService;
        private DateTime currentMonth = DateTime.Now;

        public CalendarModel Model { get; private set; }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public Command<Guid> ShowEventCommand { get; }

        public Command<DateTime> UpdateEventsIntervalCommand { get; }

        public Command RefreshCommand { get; }

        public CalendarViewModel()
        {
            RefreshCommand = new Command(RefreshCommandExecute);
            UpdateEventsIntervalCommand = new Command<DateTime>(UpdateEventsIntervalCommandExecute);
            ShowEventCommand = new Command<Guid>(ShowEventCommandExecute);
        }

        public override async Task LoadAsync()
        {
            apiService = DependencyService.Get<IApiService>();
            var events = await GetEventsByDateAsync();
            Model = new CalendarModel();
            Model.Events = new ObservableCollection<EventShortInfoDto>(events);
        }

        private async void ShowEventCommandExecute(Guid id)
        {
            MockApiService.CurrentlyOpenedEventId = id;
            await AppShell.Current.GoToAsync(nameof(CalendarEventPage));
        }

        private async void RefreshCommandExecute()
        {
            IsRefreshing = true;
            foreach (var @event in Model.Events.ToList())
            {
                Model.Events.Remove(@event);
            }
            var events = await GetEventsByDateAsync();
            foreach (var @event in events)
            {
                Model.Events.Add(@event);
            }
            IsRefreshing = false;
        }

        private void UpdateEventsIntervalCommandExecute(DateTime date)
        {
            currentMonth = date;
            RefreshCommandExecute();
        }

        private async Task<IEnumerable<EventShortInfoDto>> GetEventsByDateAsync()
        {
            return await apiService.GetEventsByDateIntervalAsync(GetMonthStart(currentMonth), GetMonthEnd(currentMonth));
        }

        private static ScheduleAppointment CreateAppointment(EventShortInfoDto @event)
        {
            return new ScheduleAppointment()
            {
                Color = @event.Color,
                IsAllDay = @event.IsAllDay,
                Subject = @event.Name,
                EndTime = @event.EndTime,
                StartTime = @event.StartTime,
                Id = @event.Id,
            };
        }

        private static DateTime GetMonthStart(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private static DateTime GetMonthEnd(DateTime date)
        {
            var month = date.Month + 1;
            var year = date.Year;
            if (date.Month == 12)
            {
                month = 1;
                year += 1;
            }
            return new DateTime(year, month, 1);
        }
    }
}
