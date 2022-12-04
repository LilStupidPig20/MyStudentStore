
using RTF.Mobile.Utils.Models;
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
        }

        private void RegisterCommandExecute()
        {
            throw new NotSupportedException();
            throw new NotImplementedException("Hello");
        }

     
    }
}
