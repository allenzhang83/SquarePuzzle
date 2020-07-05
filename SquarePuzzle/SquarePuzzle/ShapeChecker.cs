using SquarePuzzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquarePuzzle
{
    public static class ShapeChecker
    {
        public static bool IsNewShapreUnique(Shape newShape, List<Shape> currentUniqueShapes)
        {            
            if (!IsUniqueNewShape(newShape, currentUniqueShapes))
            {
                return false;
            }

            for (var i = 0; i < 3; i++)
            {
                newShape.Rotate90Degrees();
                if (!IsUniqueNewShape(newShape, currentUniqueShapes))
                {
                    return false;
                }
            }

            newShape.HorizontalFlip();

            if (!IsUniqueNewShape(newShape, currentUniqueShapes))
            {
                return false;
            }

            for (var i = 0; i < 3; i++)
            {
                newShape.Rotate90Degrees();
                if (!IsUniqueNewShape(newShape, currentUniqueShapes))
                {
                    return false;
                }
            }

            newShape.Rotate90Degrees();
            if (!IsUniqueNewShape(newShape, currentUniqueShapes))
            {
                return false;
            }

            newShape.VerticalFlip();

            if (!IsUniqueNewShape(newShape, currentUniqueShapes))
            {
                return false;
            }

            for (var i = 0; i < 3; i++)
            {
                newShape.Rotate90Degrees();
                if (!IsUniqueNewShape(newShape, currentUniqueShapes))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsUniqueNewShape(Shape newShape, List<Shape> currentUniqueShapes)
        {
            newShape.BringToOrigin();

            if (!currentUniqueShapes.Any())
            {
                return true;
            }

            foreach (var currentUniqueShape in currentUniqueShapes)
            {
                if (newShape.SameAs(currentUniqueShape))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
