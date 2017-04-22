using Gridness.Interfaces;
using Gridness.Models;

namespace GridTest.Models
{
    public class TestShape : Shape
    {
        public TestShape() { }
        public TestShape(double x, double y)
        {
            Coordinate = new Coordinate(x, y);
        }

        public Coordinate Coordinate { get; set; }
        public bool IsSelected { get; set; }
        public string Print() { return ""; }
    }
}
