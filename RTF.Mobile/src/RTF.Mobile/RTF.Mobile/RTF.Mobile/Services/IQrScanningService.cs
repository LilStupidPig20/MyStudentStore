using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
