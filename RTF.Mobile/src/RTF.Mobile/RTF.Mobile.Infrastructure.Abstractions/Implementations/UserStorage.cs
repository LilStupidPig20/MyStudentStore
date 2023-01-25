using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(UserStorage))]
namespace RTF.Mobile.Infrastructure.Abstractions.Implementations
{
    public class UserStorage : IUserStorage
    {
        private string settingsPath;
        
        private static UserSettings savedUserSettings = new UserSettings();

        public UserStorage()
        {
            var applicationFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            settingsPath = Path.Combine(applicationFolderPath, ApplicationConstants.UserSettingsFileName);
        }

        public async Task<UserSettings> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            return savedUserSettings;
            //if (File.Exists(settingsPath))
            //{
            //    using (var fileStream = FileHelper.GetFileStream(settingsPath))
            //    {
            //        return await JsonSerializer.DeserializeAsync<UserSettings>(fileStream, JsonSerializerOptions.Default, cancellationToken);
            //    }
            //}
            //return new UserSettings();
        }

        public void SaveSettings(UserSettings userSettings)
        {
            savedUserSettings = userSettings;
            //var jsonDocument = JsonSerializer.SerializeToDocument(userSettings, typeof(UserSettings));
            //using (var stream = FileHelper.GetFileStream(settingsPath, FileMode.OpenOrCreate))
            //{
            //    using (var jsonStreamWriter = new Utf8JsonWriter(stream))
            //    {
            //        jsonDocument.WriteTo(jsonStreamWriter);
            //    }
            //}
        }
    }
}
