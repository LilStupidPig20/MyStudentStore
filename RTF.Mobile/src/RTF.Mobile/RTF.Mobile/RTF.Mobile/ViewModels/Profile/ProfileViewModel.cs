using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using RTF.Mobile.Views.Profile;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Utils.PageInt;

namespace RTF.Mobile.ViewModels.Profile
{
    public class ProfileViewModel : BaseViewModel, IShellViewModel
    {
        private readonly IApiService apiService;
        private readonly IUserStorage userStorage;

        public Command UpdateInformationCommand { get; }

        public Command ShowQrCommand { get; }

        public ProfileInformationModel ProfileModel { get; private set; }

        public ObservableCollection<EventModel> Events { get; private set; }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public Command RefreshCommand { get; }

        public ProfileViewModel()
        {
            this.userStorage = DependencyService.Get<IUserStorage>();
            this.apiService = DependencyService.Get<IApiService>();
            UpdateInformationCommand = new Command(UpdateInformationCommandExecute);
            ShowQrCommand = new Command(ShowQrCommandExecute);
            RefreshCommand = new Command(RefreshCommandExecute);
            UpdateInformationCommandExecute();
        }
        
        private async void RefreshCommandExecute()
        {
            IsRefreshing = true;
            var events = await apiService.GetEventsAsync();
            foreach (var @event in Events.ToList())
            {
                Events.Remove(@event);
            }
            foreach (var @event in events)
            {
                Events.Add(new EventModel(@event.Name, @event.Points, @event.EventType));
            }
            var points = await apiService.GetCurrentUserBalanceAsync();
            ProfileModel.Points = points;
            IsRefreshing = false;
        }

        public async void UpdateInformationCommandExecute()
        {
            await apiService.LoginAsync(new LoginDto());
            var events = await apiService.GetEventsAsync();
            Events = new ObservableCollection<EventModel>(events.Select(ev => 
                new EventModel(ev.Name, ev.Points, ev.EventType)));
            var profile = await userStorage.GetSettingsAsync();
            var points = await apiService.GetCurrentUserBalanceAsync();
            ProfileModel = new ProfileInformationModel(profile.FirstName, profile.LastName, profile.Group, points);
        }

        public async void ShowQrCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(QrPage), true);
        }
    }
}
 