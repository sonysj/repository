using System;

namespace task_10_3
{

class Program
{
    static void Main()
    {
        Console.Write("Введите значение a (a > 1): ");
        double a = Convert.ToDouble(Console.ReadLine());

        if (a <= 1)
        {
            Console.WriteLine("Значение a должно быть больше 1.");
            Console.ReadKey();
            return;
        }

        double sum = 0;
        int n = 0;

        while (sum < a)
        {
            n++;
            sum += 1.0 / n;
            Console.WriteLine($"n = {n}, сумма = {sum}");
        }

        Console.WriteLine($"Сумма превысила {a} при n = {n}.");

        Console.ReadKey();
    }
}
}
