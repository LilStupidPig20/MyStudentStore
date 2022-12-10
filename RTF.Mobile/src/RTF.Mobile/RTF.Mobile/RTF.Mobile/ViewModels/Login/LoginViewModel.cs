using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views.Profile;
using RTF.Mobile.Views.Register;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Login
{
    public class LoginViewModel : EditableViewModel
    {
        public Command LoginCommand { get; }

        public Command GoToRegistrationCommand { get; }

        public LoginModel Model { get; }

        public LoginViewModel()
        {
            Model = new LoginModel();
            GoToRegistrationCommand = new Command(GoToRegistrationCommandExecute);
            LoginCommand = new Command(LoginCommandExecute);
        }

        private async void GoToRegistrationCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage), true);
        }

        private async void LoginCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(ProfilePage), true);
        }
    }
}
