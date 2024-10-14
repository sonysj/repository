namespace task_6_1;
class Program
{
    static void Main(string[] args)
    {

        var s = "прогулка";
        var word1 = s.Remove(4)
                    .Remove(3, 1)
                    .Remove(1, 1);

        word1 += s.Substring(1, 3);

        Console.WriteLine(word1);

        var word2 = ReverseString(s
            .Remove(4,4)
            .Remove(0,1));

        word2 += s.Substring(6, 2);

        Console.WriteLine(word2);

        Console.ReadKey();

    }

    static string ReverseString(string s)
    {
        return new string(s.Reverse().ToArray());

    }

}