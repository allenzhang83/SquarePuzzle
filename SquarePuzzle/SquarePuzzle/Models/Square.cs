using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace SquarePuzzle.Models
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Square(int x, int y)
        {            
            X = x;
            Y = y;
        }
    }
}
