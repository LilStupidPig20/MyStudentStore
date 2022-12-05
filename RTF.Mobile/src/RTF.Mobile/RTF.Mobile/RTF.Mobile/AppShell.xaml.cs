using RTF.Mobile.ViewModels;
using RTF.Mobile.ViewModels.Profile;
using RTF.Mobile.Views;
using RTF.Mobile.Views.Login;
using RTF.Mobile.Views.Register;
using Xamarin.Forms;

namespace RTF.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }

    }
}
