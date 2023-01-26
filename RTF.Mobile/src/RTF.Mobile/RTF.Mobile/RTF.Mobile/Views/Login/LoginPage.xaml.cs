using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //var userStorage = new UserStorage();
            //var apiService = new MockApiService(userStorage);
            ////var apiService = DependencyService.Get<IApiService>();
            this.BindingContext = new LoginViewModel();
        }
    }
}