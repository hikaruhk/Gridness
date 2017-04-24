using Gridness;
using Gridness.Interfaces;
using Gridness.Models;
using GridTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridTest
{
    [TestClass]
    public class GridManagerTest
    {
        [TestMethod]
        public void HighlightCells()
        {
            var shapeFunction = new Mock<IShapeFunctions<TestShape>>();
            var shapes = new List<TestShape>()
            {
                new TestShape(1, -1),
                new TestShape(0, 0),
                new TestShape(-1, 1)
            };

            shapeFunction.Setup(s => s.ShapesBetween(It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<double>(), It.IsAny<double>())).Returns(shapes);

            shapeFunction.Setup(s => s.CreateGrid()).Returns(TestHelper.Create1x1Grid);

            var grid = new GridManager(shapeFunction.Object);

            grid.HighlightLine(-1, 1, 1, -1);

            Assert.IsTrue(grid.Grid.Count(w => w.Value.IsSelected) == 3);
        }

        [TestMethod]
        public void HighlightCell()
        {
            var shapeFunction = new Mock<IShapeFunctions<TestShape>>();
            shapeFunction.Setup(s => s.CreateGrid()).Returns(TestHelper.Create1x1Grid);

            var grid = new GridManager(shapeFunction.Object);

            grid.Highlight(0, 0);

            Assert.IsTrue(grid.Grid.Count(w => w.Value.IsSelected) == 1);
        }

        [TestMethod]
        public void HighlightCellOverload()
        {
            var shapeFunction = new Mock<IShapeFunctions<TestShape>>();
            shapeFunction.Setup(s => s.CreateGrid()).Returns(TestHelper.Create1x1Grid);

            var grid = new GridManager(shapeFunction.Object);

            grid.Highlight(new Coordinate(0, 0));

            Assert.IsTrue(grid.Grid.Count(w => w.Value.IsSelected) == 1);
        }

        //Possibly different type of exception...
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HighlightCellInvalid()
        {
            var shapeFunction = new Mock<IShapeFunctions<TestShape>>();
            shapeFunction.Setup(s => s.CreateGrid()).Returns(TestHelper.Create1x1Grid);

            var grid = new GridManager(shapeFunction.Object);

            grid.Highlight(new Coordinate(-9, -9));
        }
    }
}
