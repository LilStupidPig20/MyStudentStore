using System.Threading.Tasks;
using RTF.Mobile.Services;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(RTF.Mobile.Droid.Resources.Services.QrScanningService))]

namespace RTF.Mobile.Droid.Resources.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Сканировать QR код", 
                BottomText = "Пожалуйста, подождите",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            if (scanResult == null)
            {
                return string.Empty;
            }
            return scanResult.Text;
        }
    }
}