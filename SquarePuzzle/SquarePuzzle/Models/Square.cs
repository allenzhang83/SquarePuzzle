using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace SquarePuzzle.Models
{
    public class Square
    {
        public List<Side> Sides { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Square(int x, int y)
        {
            Sides = new List<Side>
            {
                new Side
                {
                    Direction = Direction.East
                },
                new Side
                {
                    Direction = Direction.West
                },
                new Side
                {
                    Direction = Direction.North
                },
                new Side
                {
                    Direction = Direction.South
                },
            };

            X = x;
            Y = y;
        }
    }
}
