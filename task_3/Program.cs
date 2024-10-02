namespace task_3;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите четырехзначное число:");
        int n = int.Parse(Console.ReadLine());
        int n1 = n / 1000;
        int n2 = (n / 100) % 10;
        int n3 = (n / 10) % 10;
        int n4 = n % 10;

        int chislo = n1 * 1000 + n3 * 100 + n4 * 10 + n2 ;

        Console.WriteLine(chislo);

        Console.ReadKey();
    }
}
