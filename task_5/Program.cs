using System;

namespace task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double y = F(2, 3) + F(3, 5) + F(4,3);
            Console.WriteLine("x = " + Math.Round(y,3));

            Console.ReadKey();


        }

        static double F(double a, double b)
        {
            return Math.Sin((Math.Pow(a, a)+1)/(Math.Pow(b ,b)+1));
        }

    }
}