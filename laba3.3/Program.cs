using System.Security.Cryptography;
using System.Text;
namespace laba3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "This is a secure message";
            byte[] key = Encoding.UTF8.GetBytes("your-256-bit-secret");

            byte[] hmac = ComputeHmacSha256(Encoding.UTF8.GetBytes(message), key);

            Console.WriteLine("HMAC: " + Convert.ToBase64String(hmac));
        }
        public static byte[] ComputeHmacSha256(byte[] message, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(message);
            }
        }
    }
}
