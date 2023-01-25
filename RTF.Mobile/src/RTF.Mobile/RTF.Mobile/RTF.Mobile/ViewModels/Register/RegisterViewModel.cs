
using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views.Login;
using System;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IApiService apiService;

        public RegisterModel Model { get; } = new RegisterModel();

        public Command ComeBackCommand { get; }

        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            this.apiService = DependencyService.Get<IApiService>();
            RegisterCommand = new Command(RegisterCommandExecute);
            ComeBackCommand = new Command(GoBackCommandExecute);
        }

        public RegisterViewModel(IApiService apiService)
        {
            this.apiService = apiService;
            RegisterCommand = new Command(RegisterCommandExecute);
            ComeBackCommand = new Command(GoBackCommandExecute);
        }

        private async void RegisterCommandExecute()
        {
            var registerDto = new RegisterDto(Model.Name, Model.LastName, Model.AcademicGroup, Model.Email, Model.Password, Model.RepeatPassword);
            await apiService.RegisterAsync(registerDto);
            await Shell.Current.DisplayAlert("Уведомление", "Вы успешно зарегистрировались", "Ок");
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private async void GoBackCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
