using System.Collections.Generic;

namespace Gridness.Interfaces
{
    public interface IGrid<Shape>
    {
        IEnumerable<Shape> DrawLine(Shape a, Shape b);
        Shape Create(double x, double y);
    }
}
