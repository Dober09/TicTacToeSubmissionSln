using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeSubmissionConole
{
    //Class for holding the coordinates 
    public class Coordinates
    {
        private int _rowValue;
        private int _colValue;


        public Coordinates(int row, int column)
        {
            this.RowValue = row;
            this.ColValue = column;
        }

        public int RowValue { get => _rowValue; set => _rowValue = value; }
        public int ColValue { get => _colValue; set => _colValue = value; }

        //This method simply checks if two positions (or coordinates) are exactly the same
        public override bool Equals(object obj)
        {
            if (obj is Coordinates other)
            {
                return this.RowValue == other.RowValue && this.ColValue == other.ColValue;
            }
            return false;
        }

        // this method creates a unique number (like a fingerprint) for an object based on its row and column values
        public override int GetHashCode()
        {
            return HashCode.Combine(this.RowValue, this.ColValue);
        }
    }
}
