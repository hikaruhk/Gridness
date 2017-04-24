using Gridness.Models;
using System.Collections.Generic;

namespace Gridness.Interfaces
{
    public interface IShape
    {
        Coordinate Coordinate { get; set; }
        bool IsSelected { get; set; }
        string Print();
        IEnumerable<Coordinate> Neighbors { get; }
    }
}
