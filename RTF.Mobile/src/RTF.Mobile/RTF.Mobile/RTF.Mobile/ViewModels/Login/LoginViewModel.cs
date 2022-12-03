using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Login
{
    public class LoginViewModel : EditableViewModel
    {
        public Command LoginCommand { get; }

        public LoginModel Model { get; }

        public LoginViewModel()
        {
            Model = new LoginModel();
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
