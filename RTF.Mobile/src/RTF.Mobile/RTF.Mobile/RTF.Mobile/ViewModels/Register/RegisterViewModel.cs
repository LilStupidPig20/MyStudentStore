
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views.Login;
using System;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterModel Model { get; }

        public Command ComeBackCommand { get; }

        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecute);
            ComeBackCommand = new Command(GoBackCommandExecute);
        }

        private void RegisterCommandExecute()
        {
            throw new NotSupportedException();
            throw new NotImplementedException("Hello");
        }

        private async void GoBackCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
