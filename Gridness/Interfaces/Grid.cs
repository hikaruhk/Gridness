using System.Collections.Generic;

namespace Gridness.Interfaces
{
    public interface Grid<Shape>
    {
        IEnumerable<Shape> DrawLine(Shape a, Shape b);
        Shape Create(double x, double y);
    }
}
