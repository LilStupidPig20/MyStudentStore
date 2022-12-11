using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RTF.Mobile.Utils.MockServices
{
    public class MockApiService : IApiService
    {
        private readonly IUserStorage userStorage;

        public MockApiService(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new List<EventDto>()
            {
                new EventDto("Неделя первокурсника", 6, EventType.Social),
                new EventDto("Караоке", 2, EventType.Social),
                new EventDto("Хакатон", 5, EventType.Educational),
                new EventDto("Литературный вечер", 5, EventType.Social),
                new EventDto("Хакатон", 5, EventType.Educational),

            } as IEnumerable<EventDto>);
        }

        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
        {
            var result = new LoginResponseDto("Alexey", "Komissarov", "РИ-490023", "skaladra", "token");
            userStorage.SaveSettings(new UserSettings(result.FirstName, result.LastName, result.Group, result.UserName, result.Token));
            return Task.FromResult(result);
        }

        public Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
