namespace exam_task;
using System;
class Program
{
    static void Main()
    {
        long n = (long)Math.Pow(10, 6);
        long result = CountSquareFreePlusOne(n);
        Console.WriteLine($"C(10^6) = {result}");
        Console.ReadKey();
    }

    static long CountSquareFreePlusOne(long n)
    {
        long count = 0;

        long[] simpleSquares = new long[100];
        int squareCount = 0;

        for (long i = 2; squareCount < simpleSquares.Length; i++)
        {
            if (IsPrime(i))
            {
                simpleSquares[squareCount++] = i * i;
            }
        }

        for (long m = 1; m <= n; m++)
        {
            long squaresSum = m * m + 1;
            if (IsSquareFree(squaresSum, simpleSquares, squareCount))
            {
                count++;
            }
        }

        return count;
    }

    static bool IsPrime(long number)
    {
        if (number < 2) return false;
        for (long i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsSquareFree(long squaresSum, long[] simpleSquares, int squareCount)
    {
        for (int i = 0; i < squareCount; i++)
        {
            if (simpleSquares[i] > squaresSum) break;
            if (squaresSum % simpleSquares[i] == 0) return false;
        }
        return true;
    }
}