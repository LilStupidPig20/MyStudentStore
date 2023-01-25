using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Services;
using System;
using Xamarin.Forms;
using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.Views.Login;

namespace RTF.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Current.Properties["ApiUrl"] = "https://10.0.2.2:7140/api/";
            DependencyService.RegisterSingleton<IUserStorage>(new UserStorage());
            DependencyService.Register<IApiService, MockApiService>();
            MainPage = new LoginPage();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            HandleException(exception);
        }

        private bool HandleException(Exception exception)
        {
            switch (exception)
            {
                case NotImplementedException notImplementedException:
                    HandleNotImplementedException();
                    return true;
            }
            return false;
        }

        private async void HandleNotImplementedException()
        {
            await this.MainPage.DisplayAlert("Ошибка", "Данная функция ещё не реализована", "Хорошо");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
