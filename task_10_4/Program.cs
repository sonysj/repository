namespace task_10_4;
class Program

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

        int maxDigit = 0;
        int minDigit = 9;

        while (number > 0)
        {
            int digit = number % 10;

            if (digit > maxDigit)
                maxDigit = digit;

            if (digit < minDigit)
                minDigit = digit;

            number /= 10;
        }

        int sum = maxDigit + minDigit;

        Console.WriteLine($"Сумма минимальной и максимальной цифер равна {sum}");

        Console.ReadKey();
    }
}