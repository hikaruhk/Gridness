using Gridness.Models;
using System.Collections.Generic;

namespace Gridness.Interfaces
{
    public interface IShapeFunctions<out T> 
        where T : IShape
    {
        IDictionary<Coordinate, IShape> CreateGrid();
        IEnumerable<T> ShapesBetween(double x1, double y1, double x2, double y2);
        IEnumerable<T> ShapesBetween(IShape a, IShape b);
    }
}
