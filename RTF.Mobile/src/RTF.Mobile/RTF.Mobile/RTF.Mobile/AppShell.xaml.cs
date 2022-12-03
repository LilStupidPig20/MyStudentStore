using RTF.Mobile.Views.Auth;
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
        }

    }
}
