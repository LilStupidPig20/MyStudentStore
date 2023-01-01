using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Utils.MockServices;
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

            var userStorage = new UserStorage();
            var apiService = new MockApiService(userStorage);
            //var apiService = DependencyService.Get<IApiService>();
            //var userStorage = DependencyService.Get<IUserStorage>();
            BindingContext = new ProfileViewModel(apiService, userStorage);
        }
    }
}