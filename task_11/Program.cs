using System;

namespace task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var array = new int[n];

            Console.WriteLine($"Введите {n} элементов массива:");
            for (int i = 0; i < n; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
                    Console.Write($"Элемент {i + 1}: ");
                }
            }

            PrintArray(array);

            Console.WriteLine("Введите число k: ");

            int k;
            if (!int.TryParse(Console.ReadLine(), out k))
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var multipliedArray = CalculateMultiplication(array, k);
            PrintArray(multipliedArray);

            CalculateArithmeticMean(array);

            var swappedArray = SwapElements(array);
            PrintArray(swappedArray);

            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write($"{element} ");

            Console.WriteLine();
        }

        static int[] CalculateMultiplication(int[] array, int k)
        {
            int[] resultArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[i] * k;
            }
            return resultArray;

        }

        static void CalculateArithmeticMean(int[] array)
        {
            if (array.Length == 0)
                return;

            double sum = 0;

            foreach (int element in array)
                sum += element;

            double result = sum / array.Length;

            Console.WriteLine($"Среднее арифметическое: {result}");
        }

        static int[] SwapElements(int[] array)
        {
            int n = array.Length;
            int[] newArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = 0; i < n / 2; i++)
            {
                int temp = newArray[i];
                newArray[i] = newArray[n - 1 - i];
                newArray[n - 1 - i] = temp;
            }

            return newArray;
        }
    }
}
