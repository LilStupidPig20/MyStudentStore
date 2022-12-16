using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Interfaces
{
    public interface IUserStorage
    {
        void SaveSettings(UserSettings userSettings);

        Task<UserSettings> GetSettingsAsync(CancellationToken cancellationToken = default);
    }
}
