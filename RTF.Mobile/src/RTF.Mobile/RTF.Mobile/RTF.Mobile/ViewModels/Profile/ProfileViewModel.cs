using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Profile
{
    public class ProfileViewModel
    {
        private readonly IApiService apiService;
        private readonly IUserStorage userStorage;

        public Command UpdateInformationCommand { get; }

        public ProfileInformationModel ProfileModel { get; private set; }

        public ObservableCollection<EventModel> Events { get; private set; }

        public ProfileViewModel(IApiService apiService, IUserStorage userStorage)
        {
            this.apiService = apiService;
            this.userStorage = userStorage;
        }

        public async void UpdateInformationCommandExecute()
        {
            var events = await apiService.GetEventsAsync();
            Events = new ObservableCollection<EventModel>(events.Select(ev => 
                new EventModel(ev.Title, ev.Points, ev.EventType)));
            var profile = await userStorage.GetSettingsAsync();
            var points = events.Sum(ev => ev.Points);
            ProfileModel = new ProfileInformationModel(profile.FirstName, profile.LastName, profile.Group, points);
        }
    }
}
