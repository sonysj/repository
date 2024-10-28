using System;

namespace task_7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты точки (x, y) через пробел");
            var input = Console.ReadLine();

            var k = input.IndexOf(" ");
            var x = double.Parse(input.Substring(0, k));
            var y = double.Parse(input.Substring(k + 1));

            if (IsPointInArea(x, y))
                Console.WriteLine($"Точка ({x}; {y}) лежит в указанной области");
            else
                Console.WriteLine($"Точка ({x}; {y}) не лежит в указанной области");

            Console.ReadKey();
        }

        static bool IsPointInArea(double x, double y)
        {
            return (y <= 1.5 && y >= -2);
        }
    }
}

