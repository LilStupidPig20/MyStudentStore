using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Services;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.Utils.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Calendar
{
    public class EventViewModel : BaseViewModel
    {
        private IApiService apiService;

        public EventInfoModel Model { get; private set; }

        public Command ScanQrCommand { get; }

        public EventViewModel()
        {
            ScanQrCommand = new Command(ScanQrCommandExecute);
        }

        public override async Task LoadAsync()
        {
            apiService = DependencyService.Get<IApiService>();
            var @event = await apiService.GetFullInfoAboutEvent(MockApiService.CurrentlyOpenedEventId);
            Model = new EventInfoModel()
            {
                Id = @event.Id,
                Description = @event.Desciption,
                Points = @event.Points,
                StartDate = @event.StartTime,
                Name = @event.Name,
                Organizers = string.Join(", ", @event.OrganizersNames),
            };
        }

        private async void ScanQrCommandExecute()
        {
            var qrScanService = DependencyService.Get<IQrScanningService>();
            var text = await qrScanService.ScanAsync();
            if (Guid.TryParse(text, out var id))
            {
                var user = await apiService.GetUserInfoAsync(id);
                var result = await AppShell.Current.DisplayAlert("Зарегистрировать пользователя на мероприятие?", $"Зарегистрировать пользователя {user.FullName} на мероприятие {Model.Name}?"
                    ,"Да", "Нет");
                if (result)
                {
                    await apiService.AddUserToEvent(user.Id, Model.Id);
                    await AppShell.Current.DisplayAlert("Успех!", "Пользователь был зарегистрирован!", "Ок");
                }
            }
        }
    }
}
