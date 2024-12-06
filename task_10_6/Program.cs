using System;

namespace task_10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число m:");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите натуральное число n:");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            long sum = CalculateSum(m, n);
            Console.WriteLine($"Сумма 1^{n} + 2^{n} + ... + {m}^{n} = {sum}");
            Console.ReadKey();
        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out int num) || num <= 0)
            {
                Console.WriteLine("Число должно быть натуральным");
                return false;
            }
            number = num;
            return true;
        }

        static long Power(int baseNum, int exponent)
        {
            long result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }

        static long CalculateSum(int m, int n)
        {
            long sum = 0;
            for (int i = 1; i <= m; i++)
            {
                sum += Power(i, n);
            }
            return sum;
        }
    }
}
