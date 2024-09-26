using System.Text;
using System.Linq;
using System.IO;

namespace laba2._3
{
    internal class Program
    {
        static string Decrypt(byte[] encryptedData, byte[] key)
        {
            var decryptedBytes = new byte[encryptedData.Length];
            for (int i = 0; i < encryptedData.Length; i++)//encryptedData.Length
            {
                decryptedBytes[i] = (byte)(encryptedData[i] ^ key[i % key.Length]);//% key.Length
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        static void Main(string[] args)
        {
            string encFileName = "C:\\polina\\yniver\\kiber\\laba2.1\\data.dat";
            //string encFileName = "C:\\polina\\yniver\\kiber\\laba2.3\\encfile5.dat";
            byte[] encryptedData = File.ReadAllBytes(encFileName);
            byte[] passwordBytes = Encoding.UTF8.GetBytes("Mit21");
            //byte[] Bytes = new byte[passwordBytes.Length];
            string decryptedText;
            int position = 0;
            while (position < encryptedData.Length - passwordBytes.Length)
            {
                byte[] Bytes = new byte[passwordBytes.Length];
                for (int i = 0; i < passwordBytes.Length; i++)//encryptedData.Length
                {
                    Bytes[(i+position)%passwordBytes.Length] = (byte)(encryptedData[i+position] ^ passwordBytes[i]);//% key.Length
                }
                decryptedText = Decrypt(encryptedData, Bytes);
                if (decryptedText.Contains("Mit21"))
                {
                    Console.WriteLine("Знайдений ключ:");
                    Console.WriteLine(Encoding.UTF8.GetString(Bytes));
                    Console.WriteLine("Дешифрований текст:");
                    Console.WriteLine(decryptedText);
                }
                position++;
            }
        }
    }
}
