using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Profile
{
    internal class QrViewModel : BaseViewModel
    {
        private readonly IApiService apiService;

        public Guid UserQrId { get; private set; }

        public QrViewModel()
        {
            apiService = DependencyService.Get<IApiService>();

            UserQrId = apiService.GetUserQrIdAsync().Result;
        }
    }
}
