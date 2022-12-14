using RTF.Mobile.Services;
using RTF.Mobile.Views;
using RTF.Mobile.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            this.BindingContext = new MockDataStore();
            MainPage = new AppShell();
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
