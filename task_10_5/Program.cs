using System;

namespace Task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число");

            int number;

            if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.WriteLine("Число должно быть натуральным");
                Console.ReadKey();
                return;
            }

            int largestPrimeDivisor = -1;

            for (int divisor = 2; divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                {
                    if (IsPrime(divisor))
                    {
                        largestPrimeDivisor = divisor;
                    }
                }
            }

            if (largestPrimeDivisor != -1)
            {
                Console.WriteLine($"Наибольший простой делитель числа {number} равен {largestPrimeDivisor}");
            }
            else
            {
                Console.WriteLine($"У числа {number} нет простых делителей.");
            }

            Console.ReadKey();
        }

        static bool IsPrime(int num)
        {
            if (num < 2) return false; 
            for (int divisor = 2; divisor <= Math.Sqrt(num); divisor++)
            {
                if (num % divisor == 0) return false;
            }
            return true;
        }
    }
}