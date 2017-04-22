using Gridness;
using Gridness.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
