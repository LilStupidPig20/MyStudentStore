using RTF.Mobile.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}