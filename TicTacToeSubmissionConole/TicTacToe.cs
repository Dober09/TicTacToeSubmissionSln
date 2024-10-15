using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    /// <summary>
    /// 
    /// </summary>
    public class Coordinates{
        private int _rowValue;
        private int _colValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Coordinates(int row, int column)
        {
            this.RowValue = row;
            this.ColValue = column;
        }

        public int RowValue { get => _rowValue; set => _rowValue = value; }
        public int ColValue { get => _colValue; set => _colValue = value; }

        public override bool Equals(object obj)
        {
            if (obj is Coordinates other)
            {
                return this.RowValue == other.RowValue && this.ColValue == other.ColValue;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.RowValue, this.ColValue);
        }
    }
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private List<int> PlayerX_Positions = new List<int>();
        private List<int> PlayerO_Positions = new List<int>();


        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

     
       

        /// <summary>
        /// checkes if the values are within a bounds of 0 and 2
        /// </summary>
        /// <param name="row"> int</param>
        /// <param name="column"> int </param>
        /// <returns>True if values are within the bounds and false if not</returns>
        public static bool CheckBounds(int row, int column)
        {

            if ((row >= 0 && row <= 2) && (column >= 0 && column <= 2))
            {
                return true;
            }
            return false;
        }


        public void Run()
        {

            // couter for the number of times your are allowed to play
            int counter = 1;
         
            
            

            
            while(counter < 6)
            {


                Console.SetCursorPosition(2, 19);

                //tenary if statement for checking which player should play
                Console.Write($"Player {(counter%2==0 ? "O" :"X" )}");

                Console.SetCursorPosition(2, 20);

                

                Console.Write("Please Enter Row: ");
                var row = Console.ReadLine();

                Console.SetCursorPosition(2, 22);


                Console.Write("Please Enter Column: ");
                var column = Console.ReadLine();


                if (CheckBounds(int.Parse(row),int.Parse(column))) {

                    //store the values position for each player
                    if (counter % 2 == 0) { this.PlayerO_Positions.Add(int.Parse(row)); } else { this.PlayerX_Positions.Add(int.Parse(row)); }

                    //tenary if statement for checking which player should play
                    var player = counter % 2 == 0 ? PlayerEnum.O : PlayerEnum.X;
                    
                    // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
                    _boardRenderer.AddMove(int.Parse(row), int.Parse(column), player, true);             

                }

             
                   
                
                

                //increment the counter 
                counter++;

            }

            foreach(int pos in PlayerO_Positions)
            {
                Console.WriteLine(pos);

            }
        }





        /// <summary>
        /// This method check for a winner in the gama 
        /// <br></br>
        /// </summary>
        /// <param name="position"></param>
        /// <param name="player"></param>
        /// <returns>True if the player is winner </returns>
        public static bool CheckWinner(List<Coordinates> position)
        {

            //list of all possible winning combonation
            List<List<Coordinates>> lines = new List<List<Coordinates>>
            {
                //horizontal
                new List<Coordinates>
                {
                    new Coordinates(0,0),
                    new Coordinates(0,1),
                    new Coordinates(0,2),
                },

                new List<Coordinates>
                {
                    new Coordinates(1,0),
                    new Coordinates(1,1),
                    new Coordinates(1,2),
                },

                new List<Coordinates>
                {
                    new Coordinates(2,0),
                    new Coordinates(2,1),
                    new Coordinates(2,2),
                }
                //vertical
                , new List<Coordinates>
                {
                    new Coordinates(0,0),
                    new Coordinates(1,0),
                    new Coordinates(2,0),
                }, new List<Coordinates>
                {
                    new Coordinates(0,1),
                    new Coordinates(1,1),
                    new Coordinates(2,1),
                }, new List<Coordinates>
                {
                    new Coordinates(0,2),
                    new Coordinates(1,2),
                    new Coordinates(2,2),
                },
                //digonal
                new List<Coordinates>
                {
                    new Coordinates(0,0),
                    new Coordinates(1,1),
                    new Coordinates(2,2),
                },

                new List<Coordinates>
                {
                    new Coordinates(0,2),
                    new Coordinates(1,1),
                    new Coordinates(2,0),
                },

            };

            //loop each line and check if the player is winner
            foreach (var line in lines)
            {
                if (line.All(coord => position.Contains(coord)))
                {
                    return true;
                }

            }

            return false;
        }

    }
}
