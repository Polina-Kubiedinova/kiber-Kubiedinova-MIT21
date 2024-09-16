using System.Security.Cryptography;
namespace laba1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            byte[] randomBytes = new byte[4];
            for (int i = 0; i < length; i++)
            {

                RandomNumberGenerator.Fill(randomBytes);
                int randomNumber = BitConverter.ToInt32(randomBytes, 0);
                Console.Write(randomNumber+"|");
            }
        }
    }
}
