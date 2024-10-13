using laba4._1;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;
namespace laba4._2
{
    /*public enum HashAlgorithmTypes
    {
        MD5=1,
        SHA1=2,
        SHA256=3,
        SHA384=4,
        SHA512=5
    }*/
    public class PBKDF2
    {
        public static (string hash, string salt) GenerateHash(string password, int iterations, string choise)
        {
            string salt = SaltedHash.GenerateSalt();
            HashAlgorithmName hashAlgorithm = GetAlgorithm(choise);
            using (var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations, hashAlgorithm))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                string hash = Convert.ToBase64String(hashBytes);
                return (hash, salt);
            }
        }
        public static void DisplayHashAlgorithms()
        {
            Console.WriteLine("Choose algorithm");
            //Console.WriteLine("1.MD5");
            Console.WriteLine("1.SHA1");
            Console.WriteLine("2.SHA256");
            Console.WriteLine("3.SHA384");
            Console.WriteLine("4.SHA512");
            /*foreach (var algorithm in Enum.GetValues(typeof(HashAlgorithmType)))
            {
                Console.WriteLine($"{(int)algorithm}){algorithm}");
            }*/
        }
        public static HashAlgorithmName GetAlgorithm(string choise)
        {
            return choise switch
            {
                /*(int)HashAlgorithmType.Md5*/
                /*(int)HashAlgorithmType.Sha1*/
                "1" => HashAlgorithmName.SHA1,
                /*(int)HashAlgorithmType.Sha256*/
                "2" => HashAlgorithmName.SHA256,
                /*(int)HashAlgorithmType.Sha384*/
                "3" => HashAlgorithmName.SHA384,
                /*(int)HashAlgorithmType.Sha512*/
                "4" => HashAlgorithmName.SHA512,
                _ => HashAlgorithmName.SHA256
            };
        }
        public static long HashTime(string password, int iterations, string choise) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            GenerateHash(password, iterations, choise);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int variant = 6;
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            int firstiterations = variant * 10000;
            PBKDF2.DisplayHashAlgorithms();
            string choise = Console.ReadLine();
            Console.WriteLine(PBKDF2.GetAlgorithm(choise));
            //return;
            Stopwatch stopwatch = new Stopwatch();
            for (int i=0;i<10;i++)
            {
                int iterations = firstiterations + i * 50000;
                //int iterations = firstiterations * 2;
                stopwatch.Start();
                Console.WriteLine(iterations);
                PBKDF2.GenerateHash(password, iterations, choise);
                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Reset();
                iterations = firstiterations;
            }
        }
    }
}
