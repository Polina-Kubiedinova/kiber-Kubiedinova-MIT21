using System;

namespace laba1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length= int.Parse(Console.ReadLine());
           GenerateRandom(length);
        }
        static void GenerateRandom(int length) 
        {
            Random random = new Random(3467);
            for (int i = 0; i < length; i++)
            {
                int num1 = random.Next(0, 100);
                Console.Write($"{num1} |");
            }
            
        }
    }
}
