using laba4._1;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace laba4._3
{
    public class Hash
    {
        public static (string login, string hash, string salt) Save (string login, string password)
        {
            string salt = SaltedHash.GenerateSalt();
            //string hash = SaltedHash.ComputeHash(password, salt);
            string hash = ComputeHash(password, salt);
            return (login, hash, salt);
        }
        public static string ComputeHash(string password, string salt)
        {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
            int iterations = 6 * 10000;
            using (var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations, hashAlgorithm))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                string hash = Convert.ToBase64String(hashBytes);
                return hash;
            }
        }
        public static (string login, string hash, string salt)? finedLogin (List<(string login, string hash, string salt)> list, string login)
        {
            var result = list.SingleOrDefault(item => item.login == login);
            Console.WriteLine(result);
            if(result != default )
            {
                return result;
            }
            return null;
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string hash = ComputeHash(enteredPassword, storedSalt);
            return hash == storedHash;
        }
        // public static (string login, string hash, string salt)
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(string login, string hash, string salt)> list = new List<(string login, string hash, string salt)>();
            while (true)
            {
                Console.WriteLine("Choosee an action:");
                Console.WriteLine("1. Sign up");
                Console.WriteLine("2. Sign in");
                Console.WriteLine("3. End");
               // List<(string login, string hash, string salt)> list = new List<(string login, string hash, string salt)>();
                string c = Console.ReadLine();
                switch(c)
                {
                    case "1":
                        {
                            try
                            {
                                Console.WriteLine("Login:");
                                string login = Console.ReadLine();
                                if(Hash.finedLogin(list, login) != null)
                                {
                                    Console.WriteLine("login already registered");
                                    break;
                                }
                                Console.WriteLine("Password:");
                                string password = Console.ReadLine();
                                list.Add(Hash.Save(login, password));
                                Console.WriteLine("acount create");
                                foreach(var item in list)
                                {
                                    Console.WriteLine($"{item.login}, {item.hash}, {item.salt}");
                                }
                            }
                            catch(Exception pom)
                            {
                                Console.WriteLine($"Error{pom.Message}");
                            }
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Login:");
                                string login = Console.ReadLine();
                                (string login, string hash, string salt)? person =Hash.finedLogin(list, login);
                                if (person == null)
                                {

                                    Console.WriteLine("login not registered");
                                    break;
                                }
                                Console.WriteLine("Password:");
                                string password = Console.ReadLine();
                                while (true)
                                {
                                    if (Hash.VerifyPassword(password, person?.hash, person?.salt))
                                    {
                                        Console.WriteLine("password correct. Authorization is complete");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Password is uncorrect");
                                        Console.WriteLine("Password:");
                                        password = Console.ReadLine();
                                    }
                                }
                            }
                            catch(Exception pom)
                            {
                                Console.WriteLine($"Error{pom.Message}");
                            }
                            break;
                        }
                    case "3":
                        {
                            return;
                        }
                }
            }
        }
    }
}
