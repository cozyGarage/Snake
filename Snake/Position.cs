using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Position                                                                   // Class to define the position of the snake
    {
        public int Row { get; }
        public int Col { get; }

        public Position (int row, int column)                                                       // Constructor to define the position
        {
            Row = row;                                                                      // Row is the row value of the position
            Col = column;                                                                       // Column is the column value of the position
        }

        public Position Translate(Direction dir)                                                // This method returns the position of the snake by moving one step in the given direction
        {
            return new Position (Row + dir.RowOffset, Col + dir.ColumnOffset);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Col == position.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
