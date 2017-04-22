using Gridness.Interfaces;

namespace Gridness.Models
{
    public class Hex : Shape
    {
        public bool IsSelected { get; set; }

        public Coordinate Coordinate { get; set; }

        public Hex() { }

        public Hex(double x, double y)
        {
            Coordinate = new Coordinate(x, y);
        }

        //Simple alt code hexagons for debugging purposes
        public string Print() => IsSelected ? "⬢" : "⬡";
        //public string Print() => $"[X{Coordinate.X}Y{Coordinate.Y}]";
    }
}
