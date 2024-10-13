//using laba3._1;
using System.CodeDom.Compiler;
using System.Security.Cryptography;
using System.Text;
namespace laba4._1
{
    public class SaltedHash
    {
        private const int SaltSize = 32;
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);  // Заповнюємо масив випадковими байтами
            }
            return Convert.ToBase64String(saltBytes);
        }
        public static string ComputeHash(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string hash = ComputeHash(enteredPassword, storedSalt);
            return hash == storedHash;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            string salt = SaltedHash.GenerateSalt();
            string hash = SaltedHash.ComputeHash(password, salt);
            Console.WriteLine($"Hash:{hash}");
            Console.WriteLine($"Salt:{salt}");
            bool isvalid = SaltedHash.VerifyPassword(password, hash, salt);
            Console.WriteLine($"Password verification:{isvalid}");
        }
    }
}
