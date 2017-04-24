using Gridness.Interfaces;
using Gridness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gridness
{
    //Gridness calls the shape operations using the internal dictionary of the current shapes with coordinates.
    public class GridManager
    {
        public IDictionary<Coordinate, IShape> Grid { get; private set; }

        private readonly IShapeFunctions<IShape> GridOperations;

        public GridManager(IShapeFunctions<IShape> gridOperations)
        {
            GridOperations = gridOperations;
            Grid = gridOperations.CreateGrid();
        }

        /// <summary>
        /// Highlights from two sets of coordinates, exclusive.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void HighlightLine(double x1, double y1, double x2, double y2)
        {
            foreach (var shape in GridOperations.ShapesBetween(x1, y1, x2, y2))
            {
                Grid[shape.Coordinate].IsSelected = true;
            }
        }

        /// <summary>
        /// Highlights from two sets of coordinates, exclusive.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void HighlightLine(IShape a, IShape b)
        {
            foreach(var shape in GridOperations.ShapesBetween(a, b))
            {
                Grid[shape.Coordinate].IsSelected = true;
            }
        }

        public void Highlight(double x, double y) => Highlight(new Coordinate(x, y));

        public void Highlight(Coordinate coordinate)
        {
            var shape = default(IShape);

            if (Grid.TryGetValue(coordinate, out shape))
            {
                shape.IsSelected = true;
            }
        }

        public string Print(string space)
        {
            var radius = (int)Math.Round((Math.Sqrt(Grid.Count) / 2));

            var printedGrid = new StringBuilder(Grid.Count);

            for (int q = -radius; q <= radius; ++q)
            {
                int r1 = Math.Max(-radius, -q - radius);
                int r2 = Math.Min(radius, -q + radius);

                for (int i = 0; i < Math.Abs(q); ++i)
                {
                    printedGrid.Append(space);
                }

                for (int x = r1, y = r2; x <= r2; ++x, --y)
                {
                    var shape = Grid[new Coordinate(x, y)];

                    printedGrid.Append("-");
                    printedGrid.Append(shape.Print());
                }

                printedGrid.AppendLine();
            }

            return printedGrid.ToString();
        }
    }
}
