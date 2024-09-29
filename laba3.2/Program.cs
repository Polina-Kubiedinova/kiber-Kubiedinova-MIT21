using System.Security.Cryptography;
using System.Text;
namespace laba3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetHash = "40pmQeuOAb73MM215vbOTg==";// MD5 хеш пароля
            Guid gyid = new Guid(Convert.FromBase64String(targetHash));
            Console.WriteLine(gyid);
            for (int i = 0; i < 100000000; i++)
            {
                string candidate = i.ToString("D8"); // Формат числа як 8-значний пароль
                if (ComputeMd5(candidate) == targetHash)
                {
                    Console.WriteLine("Пароль знайдено: " + candidate);
                    break;
                }
            }
        }
        static string ComputeMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
