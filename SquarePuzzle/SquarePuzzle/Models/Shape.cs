using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquarePuzzle.Models
{
    public class Shape
    {
        public List<Square> Squares { get; set; }

        public Shape()
        {
            Squares = new List<Square>();
        }

        public void BringToOrigin()
        {
            var mostWest = Squares.Min(s => s.X);
            var mostSouth = Squares.Min(s => s.Y);

            foreach (var sqaure in Squares)
            {
                sqaure.X = sqaure.X - mostWest;
                sqaure.Y = sqaure.Y - mostSouth;
            }
        }

        public bool SameAs(Shape shapeB)
        {
            foreach (var sqaure in Squares)
            {
                if (!shapeB.Squares.Any(s => s.X == sqaure.X && s.Y == sqaure.Y))
                {
                    return false;
                }
            }
            return true;
        }

        public void Rotate90Degrees()
        {            
            foreach (var square in Squares)
            {
                var tmpX = square.Y;
                var tmpY = (0 - square.X);
                square.X = tmpX;
                square.Y = tmpY;
            }
        }

        public void HorizontalFlip()
        {
            foreach (var square in Squares)
            {                
                square.X = (0 - square.X);
                square.Y = square.Y;
            }
        }

        public void VerticalFlip()
        {
            foreach (var square in Squares)
            {
                square.X = square.X;
                square.Y = (0 - square.Y);
            }
        }

        public void CalculateTouchingSide()
        {
            foreach (var square in Squares)
            {
                foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                {
                    if (HasAdjacent(square, direction))
                    {
                        var side = square.Sides.First(s => s.Direction == direction);
                        side.HasAdjacentSquare = true;
                    }
                }                
            }
        }

        private bool HasAdjacent(Square square, Direction direction)
        {
            int x = 0;
            int y = 0;

            switch (direction)
            {
                case Direction.East:
                    x = square.X + 1;
                    y = square.Y;
                    break;
                case Direction.West:
                    x = square.X - 1;
                    y = square.Y;
                    break;
                case Direction.North:
                    x = square.X;
                    y = square.Y + 1;
                    break;
                case Direction.South:
                    x = square.X;
                    y = square.Y - 1;
                    break;
            }

            return Squares.Any(s => s.X == x && s.Y == y);
        }
    }
}
