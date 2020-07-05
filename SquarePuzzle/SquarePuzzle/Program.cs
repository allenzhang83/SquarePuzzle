using SquarePuzzle.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.WebSockets;

namespace SquarePuzzle
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type the number of squares:");

                int numberOfSquares = 0;

                while (true)
                {
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out numberOfSquares))
                    {
                        Console.WriteLine("Input has to be a number.");
                        continue;
                    }

                    if (numberOfSquares <= 0)
                    {
                        Console.WriteLine("Input has to be greater than zero.");
                        continue;
                    }
                    break;
                }

                var initialShape = InitUniqueShape();

                var previousUniqueShapes = new List<Shape>
            {
                initialShape
            };

                var currentUniqueShapes = new List<Shape>();

                for (var i = 0; i < (numberOfSquares - 1); i++)
                {
                    currentUniqueShapes.Clear();
                    foreach (var shape in previousUniqueShapes)
                    {
                        foreach (var square in shape.Squares)
                        {
                            foreach (var side in square.Sides)
                            {
                                if (side.HasAdjacentSquare)
                                {
                                    continue;
                                }

                                var newShape = AddSquare(shape, square, side);

                                var isUnique = ShapeChecker.IsNewShapreUnique(newShape, currentUniqueShapes);

                                if (isUnique)
                                {
                                    currentUniqueShapes.Add(newShape);
                                }
                            }
                        }
                    }

                    previousUniqueShapes = new List<Shape>(currentUniqueShapes);
                }

                PrintShapes(previousUniqueShapes);

                Console.WriteLine($"{numberOfSquares} squares has {previousUniqueShapes.Count()} solutions.");
                Console.ReadLine();
            }            
        }

        private static void PrintShapes(List<Shape> previousUniqueShapes)
        {
            var allSquares = new List<Square>();

            foreach (var shape in previousUniqueShapes)
            {
                allSquares.AddRange(shape.Squares);
            }

            var maxLength = allSquares.Max(s => s.X);
            var maxHeight = allSquares.Max(s => s.Y);

            var max = maxLength >= maxHeight ? maxLength : maxHeight;

            foreach (var shape in previousUniqueShapes)
            {
                for (var i = 0; i <= max; i++) 
                {
                    string toWrite = string.Empty;
                    for (var j = 0; j < max; j++)
                    {
                        var hasSquare = shape.Squares.Any(s => s.X == i && s.Y == j);
                        char toPrint = hasSquare ? '#': ' ';
                        toWrite += toPrint;
                    }
                    Console.WriteLine(toWrite);
                }
                Console.WriteLine('\n');
            }
        }

        private static Shape AddSquare(Shape previousUniqueShape, Square square, Side side)
        {
            var newShape = new Shape();

            // clone existing squares
            var otherSquares = previousUniqueShape.Squares.Where(s => s != square);
            foreach(var existingSquare in previousUniqueShape.Squares)
            {
                var cloneSquare = new Square(existingSquare.X, existingSquare.Y);
                for (var i = 0; i < 4; i++)
                {
                    cloneSquare.Sides[i].Direction = existingSquare.Sides[i].Direction;
                    cloneSquare.Sides[i].HasAdjacentSquare = existingSquare.Sides[i].HasAdjacentSquare;                    
                }
                newShape.Squares.Add(cloneSquare);
            }

            // add new square
            var x = 0;
            var y = 0;

            switch (side.Direction)
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

            var newSquare = new Square(x, y);
            newShape.Squares.Add(newSquare);
            newShape.CalculateTouchingSide();

            return newShape;
        }

        private static Shape InitUniqueShape()
        {
            var shape = new Shape();
            var initialSquare = new Square(0, 0);

            shape.Squares.Add(initialSquare);

            return shape;
        }
    }
}
