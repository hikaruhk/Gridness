using Gridness;
using Gridness.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GridTest
{
    [TestClass]
    public class HexTests
    {
        //Not really a unit test, but something I use for debugging.
        [TestMethod]
        public void GenerateHexGrid()
        {
            var functions = new HexFunctions<Hex>(5);
            var grid = new GridManager(functions);

            grid.HighlightLine(0, 0, 5, -3);

            var printedGrid = grid.Print("-");

            /*
                Debug printout.
            */

            var section = string.Join("", Enumerable.Repeat("*", 30));

            System.Diagnostics.Debug.WriteLine(section);
            System.Diagnostics.Debug.Write(printedGrid);
            System.Diagnostics.Debug.WriteLine(section);
        }

        [TestMethod]
        public void NeighborsFromCenter()
        {
            var hex = new Hex(0, 0);
            var neighbors = hex.Neighbors.ToList();
            
            //Center will always have 6 neighbors.
            Assert.IsTrue(neighbors.Count == 6);
        }

        [TestMethod]
        public void NeighborsByCoordinates()
        {
            var hex = new Hex(0, 0);
            var neighbors = hex.Neighbors;

            foreach(var neighbor in neighbors)
            {
                Assert.IsTrue(neighbor.X <= 1 || neighbor.X >= -1);
                Assert.IsTrue(neighbor.Y <= 1 || neighbor.Y >= -1);
                Assert.IsTrue(neighbor.Z <= 1 || neighbor.Z >= -1);
            }
        }

        [TestMethod]
        public void NeighborsHaveDiffCoordinates()
        {
            var hex = new Hex(0, 0);
            var neighbors = hex.Neighbors;

            foreach (var neighbor in neighbors)
            {
                var hash = new HashSet<double>();

                Assert.IsTrue(hash.Add(neighbor.X));
                Assert.IsTrue(hash.Add(neighbor.Y));
                Assert.IsTrue(hash.Add(neighbor.Z));
            }
        }

        [TestMethod]
        public void NeighborsUnique()
        {
            var hex = new Hex(0, 0);
            var neighbors = hex.Neighbors;
            var hash = new HashSet<Coordinate>();

            foreach (var neighbor in neighbors)
            {
                Assert.IsTrue(hash.Add(neighbor));
            }
        }

        [TestMethod]
        public void VerticiesUnique()
        {
            var hex = new Hex(0, 0);
            var verticies = hex.Verticies;

            var hash = new HashSet<Coordinate>();

            foreach (var vertex in verticies)
            {
                Assert.IsTrue(hash.Add(vertex));
            }
        }

        [TestMethod]
        public void VerticiesByCoordinates()
        {
            var hex = new Hex(0, 0);
            var verticies = hex.Verticies;

            foreach (var vertex in verticies)
            {
                Assert.IsTrue(vertex.X <= 1 || vertex.X >= -1);
                Assert.IsTrue(vertex.Y <= 1 || vertex.Y >= -1);
                Assert.IsTrue(vertex.Z <= 1 || vertex.Z >= -1);
            }
        }
    }
}
