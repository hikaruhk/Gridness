using Gridness.Interfaces;
using System.Collections.Generic;

namespace Gridness.Models
{
    public class Hex : IShape
    {
        public bool IsSelected { get; set; }

        public Coordinate Coordinate { get; set; }

        public Hex() { }

        public Hex(double x, double y)
        {
            Coordinate = new Coordinate(x, y);
        }

        public bool SharesVerticies(Hex hex)
        {
            var hash = new HashSet<Coordinate>(Verticies);

            foreach(var vertex in hex.Verticies)
            {
                if(!hash.Add(vertex))
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<Coordinate> Verticies
        {
            get
            {
                yield return new Coordinate() { X = Coordinate.X - 1, Y = Coordinate.Y, Z = Coordinate.Z - 1 };
                yield return new Coordinate() { X = Coordinate.X - 1, Y = Coordinate.Y - 1, Z = Coordinate.Z };
                yield return new Coordinate() { X = Coordinate.X, Y = Coordinate.Y - 1, Z = Coordinate.Z - 1 };
                yield return new Coordinate() { X = Coordinate.X, Y = Coordinate.Y - 1, Z = Coordinate.Z };
                yield return new Coordinate() { X = Coordinate.X - 1, Y = Coordinate.Y, Z = Coordinate.Z };
                yield return new Coordinate() { X = Coordinate.X, Y = Coordinate.Y, Z = Coordinate.Z - 1 };
            }
        }

        public IEnumerable<Coordinate> Neighbors
        {
            get
            {
                yield return new Coordinate() { X = Coordinate.X, Y = Coordinate.Y + 1, Z = Coordinate.Z - 1 };
                yield return new Coordinate() { X = Coordinate.X + 1, Y = Coordinate.Y, Z = Coordinate.Z - 1 };
                yield return new Coordinate() { X = Coordinate.X - 1, Y = Coordinate.Y + 1, Z = Coordinate.Z };
                yield return new Coordinate() { X = Coordinate.X + 1, Y = Coordinate.Y - 1, Z = Coordinate.Z };
                yield return new Coordinate() { X = Coordinate.X, Y = Coordinate.Y - 1, Z = Coordinate.Z + 1 };
                yield return new Coordinate() { X = Coordinate.X - 1, Y = Coordinate.Y, Z = Coordinate.Z + 1 };
            }
        }

        //Simple alt code hexagons for debugging purposes
        public string Print() => IsSelected ? "⬢" : "⬡";
        //public string Print() => $"[X{Coordinate.X}Y{Coordinate.Y}]";
    }
}
