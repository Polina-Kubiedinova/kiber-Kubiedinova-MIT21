using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace laba2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFileName = "C:\\polina\\yniver\\kiber\\laba2.1\\data.txt";
            string writeFileName = Path.ChangeExtension(readFileName, ".dat");//змінюємо тип файлу на .dat
            Console.Write("Придумайте пароль не менше ніж з 8 символів: ");
            string password = Console.ReadLine();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);//перетворюємо пароль в масив байтів
            try
            {
                byte[] decData = File.ReadAllBytes(readFileName);//зчитуємо всі байти з файлу
                byte[] keyBytes = new byte[decData.Length];//масив байтів ключа з довжиною байтів файлу
                for (int i = 0; i < decData.Length; i++)
                {
                    keyBytes[i] = passwordBytes[i % passwordBytes.Length];
                }
                byte[] encData = new byte[decData.Length];//місце для зберігання масиву результатів
                for (int i = 0; i < decData.Length; i++)
                {
                    encData[i] = (byte)(decData[i] ^ keyBytes[i]);//виконуємо функцію XOR - шифрування
                }
                File.WriteAllBytes(writeFileName, encData);
                Console.WriteLine($"Файл {readFileName} успішно зашифровано та збережено як {writeFileName}");
            }
            catch (Exception pom)
            {
                Console.WriteLine($"Помилка: {pom.Message}");
            }

        }
    }
}
