using Gridness.Interfaces;
using Gridness.Models;
using System;
using System.Collections.Generic;

namespace Gridness
{
    public class HexFunctions<T> : IShapeFunctions<T>
        where T : IShape, new()
    {
        private readonly int Radius;

        public HexFunctions(int radius)
        {
            Radius = radius;
        }

        public IDictionary<Coordinate, IShape> CreateGrid()
        {
            var grid = new Dictionary<Coordinate, IShape>();

            for (int q = -Radius; q <= Radius; ++q)
            {
                int r1 = Math.Max(-Radius, -q - Radius);
                int r2 = Math.Min(Radius, -q + Radius);

                for (int r = r1; r <= r2; ++r)
                {
                    var coordinate = new Coordinate(r, q);
                    var shape = new T() { Coordinate = coordinate };

                    grid.Add(coordinate, shape);
                }
            }

            return grid;
        }

        public IEnumerable<T> ShapesBetween(double x1, double y1, double x2, double y2) =>
            ShapesBetween(Create(x1, y1), Create(x2, y2));
            

        //Return a line of shapes from shape A -> shape B
        public IEnumerable<T> ShapesBetween(IShape a, IShape b)
        {
            var distance = Distance(a, b);

            for (int i = 0; i <= distance; ++i)
            {
                var hexLerp = CubeLerp(a, b, 1.0 / distance * i);
                yield return CubeRound(hexLerp);
            }
        }

        //Makes sure that when we are in floating pointed coordinates,
        //that we choose the right (consistant) hex.
        private T CubeRound(IShape shape)
        {
            var roundedX = Math.Round(shape.Coordinate.X);
            var roundedY = Math.Round(shape.Coordinate.Y);
            var roundedZ = Math.Round(shape.Coordinate.Z);

            var diffX = Math.Abs(roundedX - shape.Coordinate.X);
            var diffY = Math.Abs(roundedY - shape.Coordinate.Y);
            var diffZ = Math.Abs(roundedZ - shape.Coordinate.Z);

            if (diffX > diffY && diffX > diffZ)
            {
                roundedX = -roundedY - roundedZ;
            }
            else if (diffY > diffZ)
            {
                roundedY = -roundedX - roundedZ;
            }

            //Change to return coordinates?
            return Create(roundedX, roundedY);
        }

        //Change to return coordinates?
        private T CubeLerp(IShape a, IShape b, double c) =>
            Create(Lerp(a.Coordinate.X, b.Coordinate.X, c),
                Lerp(a.Coordinate.Y, b.Coordinate.Y, c));

        private double Lerp(double a, double b, double c) => a + (b - a) * c;

        //Get the distance between two hexes. This is prob gonna be used a lot.
        private double Distance(IShape a, IShape b) =>
            (Math.Abs(a.Coordinate.X - b.Coordinate.X) + 
            Math.Abs(a.Coordinate.Y - b.Coordinate.Y) + 
            Math.Abs(a.Coordinate.Z - b.Coordinate.Z)) / 2;

        private T Create(double x, double y) => new T() { Coordinate = new Coordinate(x, y) };
    }
}
