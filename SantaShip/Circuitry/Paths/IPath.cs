using System.Collections.Generic;
using System.Drawing;

namespace SantaShip.Circuitry.Paths
{
    public interface IPath
    {
        Point StartPoint { get; }
        Point EndPoint { get; }
        int PathLength { get; }
        List<Point> Get();
        IEnumerable<int> GetDistanceRange();
    }
}
