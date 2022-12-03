using Microsoft.Toolkit.Mvvm.Input;
using RTF.Mobile.Utils.Models;

namespace RTF.Mobile.ViewModels.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterModel Model { get; }

        public RelayCommand ComeBackCommand { get; }

        public RelayCommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            
        }

        private async void RegisterCommandExecute()
        {

        }

     
    }
}
