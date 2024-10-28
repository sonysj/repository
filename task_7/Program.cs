using System;

namespace Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = GetNumber("n");

            if (IsStatementTrue(n))
                Console.WriteLine("Утверждение истинно");
            else
                Console.WriteLine("Утверждение ложно");

            Console.ReadKey();
        }

        static bool IsStatementTrue(int n)
        {
            return n % 5 != 0 && n % 8 != 0; 
        }

        static int GetNumber(string numberName)
        {
            Console.WriteLine($"Введите число {numberName}");
            return int.Parse(Console.ReadLine());
        }
    }
}