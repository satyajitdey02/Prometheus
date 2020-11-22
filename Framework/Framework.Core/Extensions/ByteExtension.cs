using System.Text;

namespace Framework.Core.Extensions
{
    public static class ByteExtension
    {
        public static string GetString(this byte[] byteString)
        {
            return Encoding.UTF8.GetString(byteString);
        }
    }
}
