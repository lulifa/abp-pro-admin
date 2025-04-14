using System.Security.Cryptography;
using System.Text;

namespace System.IO
{
    internal static class FileSystemExtensions
    {
        public static string MD5(this FileStream stream)
        {
            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
            using MD5 md5 = Security.Cryptography.MD5.Create(); // Updated to use MD5.Create() instead of MD5CryptoServiceProvider
            byte[] retVal = md5.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            stream.Seek(0, SeekOrigin.Begin);
            return sb.ToString();
        }
    }
}
