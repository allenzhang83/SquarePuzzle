using System;
using System.Collections.Generic;
using System.Text;

namespace SquarePuzzle.Models
{
    public class Side
    {
        public Direction Direction { get; set; }
        public bool HasAdjacentSquare { get; set; }
    }
}
