using System;

namespace task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x");
            var x = double.Parse(Console.ReadLine());

            var y = MyFunction(x);

            Console.WriteLine("f(x)= " + y);

            Console.ReadKey();
        }

        static double MyFunction(double x)
        {
            return (-Math.Pow(x, 3) + (1 / (Math.Pow(x, 2) + 1))) / (1 + (5 / (Math.Pow(x, 2) + x + 1)));
        }
    }
}