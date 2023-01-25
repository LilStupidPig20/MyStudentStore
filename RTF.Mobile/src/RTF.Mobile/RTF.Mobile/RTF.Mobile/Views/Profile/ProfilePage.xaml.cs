using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.ViewModels.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = new ProfileViewModel();
        }
    }
}