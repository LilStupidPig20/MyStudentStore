using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.ViewModels.Calendar;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Calendar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarPage : ContentPage
	{
		public CalendarPage ()
		{
			InitializeComponent();

            BindingContext = new CalendarViewModel();
        }

        private void schedule_VisibleDatesChangedEvent(object sender, Syncfusion.SfSchedule.XForms.VisibleDatesChangedEventArgs e)
        {
			var currentDate = e.visibleDates[e.visibleDates.Count / 2].Date;
            var calendarViewModel = (CalendarViewModel)BindingContext;
			calendarViewModel.UpdateEventsIntervalCommand.Execute(currentDate);
        }

        private void schedule_MonthInlineAppointmentTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
        {
            var calendarViewModel = (CalendarViewModel)BindingContext;
            var appointment = e.Appointment as EventShortInfoDto;
            if (appointment != null)
            {
                calendarViewModel.ShowEventCommand.Execute(appointment.Id);
            }
        }
    }
}