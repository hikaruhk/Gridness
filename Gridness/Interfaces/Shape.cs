using Gridness.Models;

namespace Gridness.Interfaces
{
    public interface Shape
    {
        Coordinate Coordinate { get; set; }
        bool IsSelected { get; set; }
        string Print();
    }
}
