using SquarePuzzle.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SquarePuzzle.Test
{
    public class UniqueShapeTest
    {
        [Fact]
        public void Duplicated_Shape_Should_Not_Pass()
        {
            var square00 = new Square(0, 0);
            var square10 = new Square(1, 0);
            var square20 = new Square(2, 0);
            var square30 = new Square(3, 0);
            var square11 = new Square(1, 1);
            var square01 = new Square(0, 1);
            var square02 = new Square(0, 2);

            var shape1 = new Shape();
            shape1.Squares.Add(square00);
            shape1.Squares.Add(square10);
            shape1.Squares.Add(square11);
            shape1.Squares.Add(square20);

            var shape2 = new Shape();
            shape2.Squares.Add(square00);
            shape2.Squares.Add(square10);
            shape2.Squares.Add(square11);
            shape2.Squares.Add(square01);

            var shape3 = new Shape();
            shape3.Squares.Add(square00);
            shape3.Squares.Add(square10);
            shape3.Squares.Add(square20);
            shape3.Squares.Add(square30);

            var shape4 = new Shape();
            shape4.Squares.Add(square00);
            shape4.Squares.Add(square10);
            shape4.Squares.Add(square20);
            shape4.Squares.Add(square01);

            var shape5 = new Shape();
            shape5.Squares.Add(square01);
            shape5.Squares.Add(square11);
            shape5.Squares.Add(square10);
            shape5.Squares.Add(square20);

            var currentUniqueShapes = new List<Shape>
            {
                shape1,
                shape2,
                shape3,
                shape4,
                shape5
            };

            var testShape = new Shape();
            testShape.Squares.Add(square00);
            testShape.Squares.Add(square10);
            testShape.Squares.Add(square01);
            testShape.Squares.Add(square02);

            var isUnique = ShapeChecker.IsNewShapreUnique(testShape, currentUniqueShapes);

            Assert.False(isUnique);
        }
    }
}
