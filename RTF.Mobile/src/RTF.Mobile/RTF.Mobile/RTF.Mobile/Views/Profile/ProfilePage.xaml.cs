using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.ViewModels.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            var apiService = DependencyService.Get<IApiService>();
            var userStorage = DependencyService.Get<IUserStorage>();
            BindingContext = new ProfileViewModel(apiService, userStorage);
        }
    }
}