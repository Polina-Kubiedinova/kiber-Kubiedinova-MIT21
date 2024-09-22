using System.Text;
using System.Linq;
using System.IO;

namespace laba2._3
{
    internal class Program
    {
        static string Decrypt(byte[] encryptedData, string key)
        {
            var decryptedBytes = new byte[encryptedData.Length];
            for (int i = 0; i < encryptedData.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedData[i] ^ key[i % key.Length]);
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        static IEnumerable<string> GenerateKeys(string charset, int length)
        {
            // Рекурсивна генерація всіх комбінацій
            if (length == 1) return charset.Select(c => c.ToString());
            return GenerateKeys(charset, length - 1)
                .SelectMany(t => charset, (t, c) => t + c);
        }
        static void Main(string[] args)
        {
            string encFileName = "C:\\polina\\yniver\\kiber\\laba2.3\\encfile5.dat";
            byte[] encryptedData = File.ReadAllBytes(encFileName);
            string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int keyLength = 5;
            foreach (var key in GenerateKeys(charset, keyLength))
            {
                string decryptedText = Decrypt(encryptedData, key);
                if (decryptedText.Contains("Mit21"))
                {
                    Console.WriteLine($"Знайдено ключ: {key}");
                    Console.WriteLine("Дешифрований текст:");
                    Console.WriteLine(decryptedText);
                    break;
                }
            }
        }
    }
}
