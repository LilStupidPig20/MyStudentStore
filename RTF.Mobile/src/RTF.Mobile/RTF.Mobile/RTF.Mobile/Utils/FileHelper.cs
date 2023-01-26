using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace RTF.Mobile.Utils
{
    internal class FileHelper
    {
        public MemoryStream GetStreamFromFile(string fileName)
        {
            var applicationTypeInfo = Application.Current.GetType().GetTypeInfo();

            var names = applicationTypeInfo.Assembly.GetManifestResourceNames();
            byte[] buffer = new byte[0];
            using (var stream = applicationTypeInfo.Assembly.GetManifestResourceStream($"{applicationTypeInfo.Namespace}.{fileName}"))
            {
                if (stream != null)
                {
                    long length = stream.Length;
                    buffer = new byte[length];
                    stream.Read(buffer, 0, (int)length);
                }
            }

            return new MemoryStream(buffer);
        }
    }
}
