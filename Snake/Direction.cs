using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Direction                                                                              // Class to control how the snake moves
    {
        public readonly static Direction Left = new(0, -1);                                             // Directions row value is unchanged, column value is offset by -1
        public readonly static Direction Right = new(0, 1);                                             // Directions row value is unchanged, column value is offset by 1
        public readonly static Direction Up = new(-1, 0);                                               // Directions row value is offset by -1, column value is unchanged
        public readonly static Direction Down = new(1, 0);                                              // Directions row value is offset by 1, column value is unchanged

        public int RowOffset { get; }
        public int ColumnOffset { get; }

        private Direction(int rowOffset, int columnOffset)                                              // Constructor to define the direction
        {
            RowOffset = rowOffset;
            ColumnOffset = columnOffset;
        }

        public Direction Opposite()                                                                     // Method to define the opposite direction
        {
            return new Direction(-RowOffset, -ColumnOffset);
        }

        public override bool Equals(object obj)                                                             // Method to define the equality of the direction
        {
            return obj is Direction direction &&
                   RowOffset == direction.RowOffset &&
                   ColumnOffset == direction.ColumnOffset;
        }

        public override int GetHashCode()                                                               // Method to define the hash code of the direction gererated by the Visual Studio IDE
        {
            return HashCode.Combine(RowOffset, ColumnOffset);
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }
    }
}
