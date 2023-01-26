using RTF.Mobile.ViewModels.Calendar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarEventPage : ContentPage
    {
        public CalendarEventPage()
        {
            InitializeComponent();

            BindingContext = new EventViewModel();
        }
    }
}