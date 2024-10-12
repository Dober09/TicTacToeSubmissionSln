using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

        
         /// <summary>
         /// This method gives the results for game if player O or player X won the game
         /// </summary>
         /// 
        public static char? CheckWinner(char[,] board)
        {

            return null;
        }


        public void Run()
        {

            // couter for the number of times your are allowed to play
            int counter = 1;
            // The two Players
            
            

            
            while(counter < 6)
            {


                Console.SetCursorPosition(2, 19);

                //tenary if statement for checking which player should play
                Console.Write($"Player {(counter%2==0 ? "O" :"X" )}");

                Console.SetCursorPosition(2, 20);

                //check if the input is within the bounds
                //if (row < 0 || row > 2 || column < 0 || column > 2)

                Console.Write("Please Enter Row: ");
                var row = Console.ReadLine();

                Console.SetCursorPosition(2, 22);


                Console.Write("Please Enter Column: ");
                var column = Console.ReadLine();


                // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
                //tenary if statement for checking which player should play
                
                var player = counter % 2 == 0 ? PlayerEnum.O : PlayerEnum.X;
                _boardRenderer.AddMove(int.Parse(row), int.Parse(column), player, true);             

                //increment the counter 
                counter++;

            }
        }

    }
}
