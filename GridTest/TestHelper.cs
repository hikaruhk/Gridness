using Gridness.Interfaces;
using Gridness.Models;
using GridTest.Models;
using System.Collections.Generic;

namespace GridTest
{
    internal static class TestHelper
    {
        public static IDictionary<Coordinate, Shape> Create1x1Grid
        {
            get
            {
                return new Dictionary<Coordinate, Shape>()
                {
                    { new Coordinate(0, 1), new TestShape(0, 1) },
                    { new Coordinate(1, 0), new TestShape(1, 0) },
                    { new Coordinate(-1, 1), new TestShape(-1, 1) },
                    { new Coordinate(0, 0), new TestShape(0, 0) },
                    { new Coordinate(1, -1), new TestShape(1, -1)},
                    { new Coordinate(-1, 0), new TestShape(-1, 0) },
                    { new Coordinate(0, -1), new TestShape(0, -1) },
                };
            }
        }
    }
}
