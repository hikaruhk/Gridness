using Gridness;
using GridTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GridTest
{
    [TestClass]
    public class HexFunctionsTest
    {
        [TestMethod]
        public void GetLineOfShapes()
        {
            var functions = new HexFunctions<TestShape>(5);

            //Moving to the center to the far left;
            var hex1 = new TestShape(0, 0);
            var hex2 = new TestShape(5, 0);

            var hexes = functions.ShapesBetween(hex1, hex2).ToList();

            //Returned hexes are exclusive.
            Assert.IsTrue(hexes.Count == 6);
        }

        [TestMethod]
        public void GetCurvedLineOfHexes()
        {
            var functions = new HexFunctions<TestShape>(5);

            /*

                    ⬡  ⬡  ⬡  ⬡  ⬡  ⬡
                  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡
                ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡
              ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬢
            ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬢  ⬢  ⬡
          ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬢  ⬡  ⬡  ⬡
            ⬡  ⬡  ⬡  ⬡  ⬡  ⬡  ⬢  ⬡  ⬡  ⬡
              ⬡  ⬡  ⬡  ⬡  ⬢  ⬢  ⬡  ⬡  ⬡
                ⬡  ⬡  ⬡  ⬢  ⬡  ⬡  ⬡  ⬡
                  ⬡  ⬢  ⬢  ⬡  ⬡  ⬡  ⬡
                    ⬢  ⬡  ⬡  ⬡  ⬡  ⬡

            */
            var hexagons = functions.ShapesBetween(-5, 0, 5, -3);

            //From the first point the the last point should be 11 going diag. 
            Assert.IsTrue(hexagons.Count() == 11);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidLineOfShapes()
        {
            var functions = new HexFunctions<TestShape>(5);

            var hexagons = functions.ShapesBetween(-5, 0, 5, 9);

            //From the first point the the last point should be 11 going diag. 
            Assert.IsTrue(hexagons.Count() == 12);
        }
    }
}
