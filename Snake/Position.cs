using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Position
    {
        public int Row { get; } // The row value of the position
        public int Col { get; } // The column value of the position

        public Position(int row, int column)
        {
            Row = row; // Initialize the row value of the position
            Col = column; // Initialize the column value of the position
        }

        public Position Translate(Direction dir)
        {
            // This method returns a new position by moving one step in the given direction
            // It calculates the new row and column values based on the current position and the direction offsets
            return new Position(Row + dir.RowOffset, Col + dir.ColumnOffset);
        }

        public override bool Equals(object obj)
        {
            // Override the Equals method to compare two Position objects for equality
            // Two positions are considered equal if their row and column values are the same
            if (obj is Position position)
            {
                return Row == position.Row && Col == position.Col;
            }

            return false;
        }

        public override int GetHashCode()
        {
            // Override the GetHashCode method to generate a unique hash code for the Position object
            // The hash code is calculated based on the row and column values of the position
            return HashCode.Combine(Row, Col);
        }

        public static bool operator ==(Position left, Position right)
        {
            // Overload the equality operator (==) to compare two Position objects for equality
            // It uses the default EqualityComparer to compare the objects
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            // Overload the inequality operator (!=) to compare two Position objects for inequality
            // It simply negates the result of the equality operator (==)
            return !(left == right);
        }
    }
}
