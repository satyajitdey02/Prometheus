using System.Text;

namespace Framework.Core.Extensions
{
    public static class StringExtension
    {
        public static byte[] GetBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
