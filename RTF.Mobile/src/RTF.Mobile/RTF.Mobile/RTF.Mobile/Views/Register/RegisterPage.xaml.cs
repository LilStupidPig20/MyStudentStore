using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.ViewModels.Register;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            var apiService = DependencyService.Get<IApiService>();
            this.BindingContext = new RegisterViewModel(apiService);
        }
    }
}