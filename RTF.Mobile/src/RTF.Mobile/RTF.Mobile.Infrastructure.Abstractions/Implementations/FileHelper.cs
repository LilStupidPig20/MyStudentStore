using RTF.Mobile.Infrastructure.Abstractions.Exceptions;
using System.IO;

namespace RTF.Mobile.Infrastructure.Abstractions.Implementations
{
    public static class FileHelper
    {
        public static byte[] ReadAllBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (IOException ex)
            {
                throw new InfrastructureException(ex.Message);
            }
        }

        public static FileStream GetFileStream(string path, FileMode mode = FileMode.Open)
        {
            try
            {
                return new FileStream(path, mode);
            }
            catch (IOException ex)
            {
                throw new InfrastructureException(ex.Message);
            }
        }

        public static void WriteAllBytes(string path, byte[] content)
        {
            try
            {
                File.WriteAllBytes(path, content);
            }
            catch (IOException ex)
            {
                throw new InfrastructureException(ex.Message);
            }
        }
    }
}
