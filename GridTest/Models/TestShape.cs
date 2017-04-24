using Gridness.Interfaces;
using Gridness.Models;
using System.Collections.Generic;

namespace GridTest.Models
{
    public class TestShape : IShape
    {
        public TestShape() { }
        public TestShape(double x, double y)
        {
            Coordinate = new Coordinate(x, y);
        }

        public IEnumerable<Coordinate> Neighbors { get { return null; } }

        public Coordinate Coordinate { get; set; }
        public bool IsSelected { get; set; }
        public string Print() { return ""; }
    }
}
