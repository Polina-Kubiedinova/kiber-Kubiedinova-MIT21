
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace laba3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string c = Console.ReadLine();
                switch (c)
                {
                    case "1" :
                        {
                            Console.WriteLine("Введіть текст: ");
                            string data = Console.ReadLine();
                            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                            var HashMD5 = ComputeHashMd5(dataBytes);
                            Guid gyid = new Guid(HashMD5);
                            var HashSha1 = ComputeHashSha1(dataBytes);
                            var HashSha256 = ComputeHashSha256(dataBytes);
                            var HashSha384 = ComputeHashSha384(dataBytes);
                            var HashSha512 = ComputeHashSha512(dataBytes);
                            Console.WriteLine("MD5: " + Convert.ToBase64String(HashMD5));
                            Console.WriteLine("GUID: " + gyid);
                            Console.WriteLine("SHA1: " + Convert.ToBase64String(HashSha1));
                            Console.WriteLine("SHA256: " + Convert.ToBase64String(HashSha256));
                            Console.WriteLine("SHA384: " + Convert.ToBase64String(HashSha384));
                            Console.WriteLine("SHA512: " + Convert.ToBase64String(HashSha512));
                            break;
                        }
                    case "2":
                        return;
                }
            } 
        }
        static byte[] ComputeHashMd5(byte[] dataForHash)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(dataForHash);
            }
        }
        static byte[] ComputeHashSha1(byte[] dataForHash)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(dataForHash);
            }
        }
        static byte[] ComputeHashSha256(byte[] dataForHash)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(dataForHash);
            }
        }

        static byte[] ComputeHashSha384(byte[] dataForHash)
        {
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(dataForHash);
            }
        }

        static byte[] ComputeHashSha512(byte[] dataForHash)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(dataForHash);
            }
        }
    }
}
