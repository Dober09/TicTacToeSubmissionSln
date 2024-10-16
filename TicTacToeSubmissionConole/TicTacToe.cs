﻿using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{


    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private List<Coordinates> PlayerX_Positions = new List<Coordinates>();
        private List<Coordinates> PlayerO_Positions = new List<Coordinates>();
        private bool gameOver = false;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        public static bool CheckBounds(int row, int column)
        {
            return (row >= 0 && row <= 2) && (column >= 0 && column <= 2);
        }

        public void Run()
        {
            int counter = 1;


            //loop of the game
            while (!gameOver && counter <= 9)
            {
                PlayerEnum currentPlayer = (counter % 2 == 0) ? PlayerEnum.O : PlayerEnum.X;

                Console.SetCursorPosition(2, 19);
                Console.Write($"Player {currentPlayer}");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row (0 to 2): ");
                var rowInput = Console.ReadLine();

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column (0 to 2): ");
                var columnInput = Console.ReadLine();

                //check if the value is within the bounds and is valid move 
                if (int.TryParse(rowInput, out int row) && int.TryParse(columnInput, out int column) &&
                    CheckBounds(row, column) && IsValidMove(row, column))
                {
                    Coordinates move = new Coordinates(row, column);

                    // add the moves in tne list for each player
                    if (currentPlayer == PlayerEnum.X)
                        PlayerX_Positions.Add(move);
                    else
                        PlayerO_Positions.Add(move);
                    //PRINT THE BOARD
                    _boardRenderer.AddMove(row, column, currentPlayer, true);

                    // check if the player is winner 
                    if (CheckWinner(currentPlayer == PlayerEnum.X ? PlayerX_Positions : PlayerO_Positions))
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (counter == 9)
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }

                    counter++;
                }
                else
                {
                    Console.SetCursorPosition(2, 24);
                    Console.WriteLine("Invalid move. Try again.");
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(2, 24);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                }
            }
        }

        /// <summary>
        /// This method checks if the move is valid
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Returns true if the move is value false if is invalid move </returns>
        public bool IsValidMove(int row, int column)
        {
            Coordinates move = new Coordinates(row, column);
            return !PlayerX_Positions.Contains(move) && !PlayerO_Positions.Contains(move);
        }

        /// <summary>
        /// This method checks the winner of the game
        /// </summary>
        /// <param name="positions"></param>
        /// <returns>Return true  if the value exist in the list </returns>
        public static bool CheckWinner(List<Coordinates> positions)
        {
            //list of all possible  winning coordinates in the game
            List<List<Coordinates>> lines = new List<List<Coordinates>>
            {
                // Horizontal
                new List<Coordinates> { new Coordinates(0,0), new Coordinates(0,1), new Coordinates(0,2) },
                new List<Coordinates> { new Coordinates(1,0), new Coordinates(1,1), new Coordinates(1,2) },
                new List<Coordinates> { new Coordinates(2,0), new Coordinates(2,1), new Coordinates(2,2) },
                // Vertical
                new List<Coordinates> { new Coordinates(0,0), new Coordinates(1,0), new Coordinates(2,0) },
                new List<Coordinates> { new Coordinates(0,1), new Coordinates(1,1), new Coordinates(2,1) },
                new List<Coordinates> { new Coordinates(0,2), new Coordinates(1,2), new Coordinates(2,2) },
                // Diagonal
                new List<Coordinates> { new Coordinates(0,0), new Coordinates(1,1), new Coordinates(2,2) },
                new List<Coordinates> { new Coordinates(0,2), new Coordinates(1,1), new Coordinates(2,0) },
            };

            return lines.Any(line => line.All(coord => positions.Contains(coord)));
        }
    }
}