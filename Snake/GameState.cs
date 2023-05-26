using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Snake
{
    public class GameState                                                                              // Class to control the game state
    {
        public int Rows { get; }                                                                        // The number of rows in the grid                   
        public int Columns { get; }                                                                     // The number of columns in the grid
        public GridValue[,] Grid { get; }                                                               // The grid representing the game state
        public Direction Dir { get; private set; }                                                      // The current direction of the snake
        public int Score { get; private set; }                                                          // The current score of the game
        public bool GameOver { get; private set; }                                                      // Flag indicating if the game is over

        private readonly LinkedList<Direction> dirChanges = new();                                      // List to store direction changes
        private readonly LinkedList<Position> snakePositions = new();                                   // List to store snake positions
        private readonly Random random = new();                                                         // Random number generator

        public GameState(int rows, int columns)                                                         // Constructor to define the game state
        {
            Rows = rows;                                                                                // Rows is the number of rows in the grid
            Columns = columns;                                                                          // Columns is the number of columns in the grid
            Grid = new GridValue[rows, columns];                                                        // Grid is the grid representing the game state
            Dir = Direction.Right;                                                                      // Dir is the current direction of the snake

            AddSnake();                                                                                 // Add the initial snake to the grid
            AddFood();                                                                                  // Add initial food to the grid
        }

        private void AddSnake()                                                                         // Method to add the initial snake to the grid
        {
            int r = Rows / 2;                                                                           // The row value of the snake's head

            for (int c = 1; c <= 3; c++)                                                                // The column values of the snake's head and body
            {
                Grid[r, c] = GridValue.Snake;                                                           // Mark grid cells as occupied by the snake
                snakePositions.AddFirst(new Position(r, c));                                            // Store snake positions
            }
        }

        private IEnumerable<Position> EmptyPosition()                                                   // Method to return empty positions
        {
                                                                                                        
            for (int r = 0; r < Rows; r++)                                                              // Iterate through the grid and yield empty positions                 
            {
                for (int c = 0; c < Columns; c++)                                                       
                {
                    if (Grid[r, c] == GridValue.Empty)                                                  // Check if the grid cell is empty
                    {
                        yield return new Position(r, c);                                                // Yield empty positions
                    }
                }
            }
        }

        private void AddFood()                                                                          // Method to add food to the grid
        {
            List<Position> empty = new(EmptyPosition());                                                // Get all empty positions           

            if (empty.Count == 0)
            {
                return;                                                                                 // No empty positions to add food
            }

            Position pos = empty[random.Next(empty.Count)];                                             // Randomly select an empty position
            Grid[pos.Row, pos.Col] = GridValue.Food;                                                    // Mark the grid cell as containing food
        }

        public Position HeadPosition()
        {
            return snakePositions.First.Value;                                                          // Get the position of the snake's head
        }

        public Position TailPosition()
        {
            return snakePositions.Last.Value;                                                           // Get the position of the snake's tail
        }

        public IEnumerable<Position> SnakePositions()
        {
            return snakePositions;                                                                      // Return all snake positions
        }

        private void AddHead(Position pos)
        {
            snakePositions.AddFirst(pos);                                                               // Add a new position as the snake's head
            Grid[pos.Row, pos.Col] = GridValue.Snake;                                                   // Mark the grid cell as occupied by the snake
        }

        private void RemoveTail()
        {
            Position tail = snakePositions.Last.Value;                                                  // Get the snake's tail position
            Grid[tail.Row, tail.Col] = GridValue.Empty;                                                 // Mark the grid cell as empty
            snakePositions.RemoveLast();                                                                // Remove the last position (snake's tail)
        }

        private Direction GetLastDirection()                                                            // Method to get the last direction change
        {
            if (dirChanges.Count == 0)
            {
                return Dir;                                                                             // If no direction changes, return the current direction
            }

            return dirChanges.Last.Value;                                                               // Return the last direction change
        }

        private bool CanChangeDirection(Direction newDir)                                               // Method to check if the direction can be changed
        {
            if (dirChanges.Count == 2)
            {
                return false;                                                                           // Only allow at most two consecutive direction changes
            }

            Direction lastDir = GetLastDirection();
            return newDir != lastDir && newDir != lastDir.Opposite();                                   // Check if the new direction is valid
        }

        public void ChangeDirection(Direction dir)
        {
            if (CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);                                                                // Add the new direction change to the list
            }  
        }

        private bool OutsiteGrid(Position pos)
        {
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Columns;                 // Check if a position is outside the grid boundaries
        }

        private GridValue WillHit(Position newHeadPos)
        {
            if (OutsiteGrid(newHeadPos))
            {
                return GridValue.Outside;                                                               // The new head position is outside the grid
            }

            if (newHeadPos == TailPosition())
            {
                return GridValue.Empty;                                                                 // The new head position is the snake's tail
            }

            return Grid[newHeadPos.Row, newHeadPos.Col];                                                // Return the value at the new head position
        }

        public void Move()
        {
            if (dirChanges.Count > 0)
            {
                Dir = dirChanges.First.Value;                                                           // Update the current direction based on the first direction change
                dirChanges.RemoveFirst();                                                               // Remove the processed direction change
            }

            Position newHeadPos = HeadPosition().Translate(Dir);                                        // Calculate the new head position based on the current direction
            GridValue hit = WillHit(newHeadPos);                                                        // Check if the new head position will hit something

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;                                                                        // Game over if the new head position is outside the grid or hits the snake itself
            }
            else if (hit == GridValue.Empty)
            {
                RemoveTail();                                                                           // Remove the tail position
                AddHead(newHeadPos);                                                                    // Add the new head position
            }
            else if (hit == GridValue.Food)
            {
                AddHead(newHeadPos);                                                                    // Add the new head position
                Score++;                                                                                // Increase the score
                AddFood();                                                                              // Add new food to the grid
            }
        }
    }
}
