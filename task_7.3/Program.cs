using System;

namespace Task_7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого слона");
            var whiteBishopPosition = Console.ReadLine();

            Console.WriteLine("Введите позицию черного коня");
            var blackKnightPosition = Console.ReadLine();

            if (whiteBishopPosition == blackKnightPosition ||
                IsWhiteBishopStrike(whiteBishopPosition, blackKnightPosition))
            {
                Console.WriteLine("Черный конь не должен стоять на этой клетке");

                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите ход белого слона");
            var move = Console.ReadLine();

            if (IsWhiteBishopCanMove(move, whiteBishopPosition, blackKnightPosition))
                Console.WriteLine("Ход разрешен");
            else
                Console.WriteLine("Ход запрещен");

            Console.ReadKey();
        }

        static bool IsWhiteBishopStrike(string whiteBishopPosition, string blackKnightPosition)
        {
            int bc, br, kc, kr;

            DecodePosition(whiteBishopPosition, out bc, out br);
            DecodePosition(blackKnightPosition, out kc, out kr);

            return Math.Abs(kc - bc) == Math.Abs(kr - br); 
        }

        static bool IsWhiteBishopCanMove(string move, string whiteBishopPosition, string blackKnightPosition)
        {
            return IsWhiteBishopMoveCorrect(move, whiteBishopPosition) &&
                   !IsBlackKnightAttacksAfterMove(move, whiteBishopPosition, blackKnightPosition);
        }

        static bool IsWhiteBishopMoveCorrect(string move, string whiteBishopPosition)
        {
            int bc, br, mc, mr;

            DecodePosition(whiteBishopPosition, out bc, out br);
            DecodePosition(move, out mc, out mr);

            return Math.Abs(mc - bc) == Math.Abs(mr - br);
        }

        static bool IsBlackKnightAttacksAfterMove(string move, string whiteBishopPosition, string blackKnightPosition)
        {
            int bc, br, kc, kr, mc, mr;

            DecodePosition(whiteBishopPosition, out bc, out br);
            DecodePosition(blackKnightPosition, out kc, out kr);
            DecodePosition(move, out mc, out mr);

            return (Math.Abs(kc - mc) == 1 && Math.Abs(kr - mr) == 2) ||
                   (Math.Abs(kc - mc) == 2 && Math.Abs(kr - mr) == 1);
        }

        static void DecodePosition(string position, out int column, out int row)
        {
            row = int.Parse(position[1].ToString());
            column = (int)position[0] - 0x60;

        }
    }
}