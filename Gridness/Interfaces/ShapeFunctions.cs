using Gridness.Models;
using System.Collections.Generic;

namespace Gridness.Interfaces
{
    public interface ShapeFunctions<out T> 
        where T : Shape
    {
        IDictionary<Coordinate, Shape> CreateGrid();
        IEnumerable<T> ShapesBetween(double x1, double y1, double x2, double y2);
        IEnumerable<T> ShapesBetween(Shape a, Shape b);
    }
}
