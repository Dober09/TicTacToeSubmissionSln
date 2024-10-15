using System;
using System.Collections.Generic;

namespace TicTacToeSubmissionConole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.SetCursorPosition(10,2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Tic Tac Toe");
            Console.WriteLine(" \t 0 \t 1 \t 2");
            var ticTacToe = new TicTacToe();

            ticTacToe.Run();
           


            Console.ForegroundColor = oldColor ;


            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Thank you for playing");
            Console.ReadLine();
        }
    }
}
