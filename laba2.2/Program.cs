using System.Text;

namespace laba2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFileName = "C:\\polina\\yniver\\kiber\\laba2.2\\data.dat";
            string writeFileName = Path.ChangeExtension(readFileName, ".txt");//змінюємо тип файлу на .dat
            Console.Write("Придумайте пароль не менше ніж з 8 символів: ");
            string password = Console.ReadLine();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);//перетворюємо пароль в масив байтів
            try
            {
                byte[] encData = File.ReadAllBytes(readFileName);//зчитуємо всі байти з файлу
                byte[] keyBytes = new byte[encData.Length];//масив байтів ключа з довжиною байтів файлу
                for (int i = 0; i < encData.Length; i++)
                {
                    keyBytes[i] = passwordBytes[i % passwordBytes.Length];
                }
                byte[] result = new byte[encData.Length];//місце для зберігання масиву результатів
                for (int i = 0; i < encData.Length; i++)
                {
                    result[i] = (byte)(encData[i] ^ keyBytes[i]);//виконуємо функцію XOR - шифрування
                }
                File.WriteAllBytes(writeFileName, result);
                Console.WriteLine($"Файл {readFileName} успішно зашифровано та збережено як {writeFileName}");
            }
            catch (Exception pom)
            {
                Console.WriteLine($"Помилка: {pom.Message}");
            }
        }
    }
}
