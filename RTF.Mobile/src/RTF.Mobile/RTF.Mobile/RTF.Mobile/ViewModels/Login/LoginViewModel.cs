using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views.Profile;
using RTF.Mobile.Views.Register;
using RTF.Mobile.Views.Shop;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Login
{
    public class LoginViewModel : EditableViewModel
    {
        private readonly IApiService apiService;

        public Command LoginCommand { get; }

        public Command GoToRegistrationCommand { get; }

        public LoginModel Model { get; } = new LoginModel();

        public LoginViewModel()
        {
            this.apiService = DependencyService.Get<IApiService>();
            GoToRegistrationCommand = new Command(GoToRegistrationCommandExecute);
            LoginCommand = new Command(LoginCommandExecute);
        }

        private async void GoToRegistrationCommandExecute()
        {
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync(nameof(RegisterPage), true);
        }

        private async void LoginCommandExecute()
        {
            var loginDto = new LoginDto(Model.Email, Model.Password, true);
            var response = await apiService.LoginAsync(loginDto);
            if (response.Token != string.Empty)
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync(nameof(ShopPage), true);
            }
        }
    }
}
