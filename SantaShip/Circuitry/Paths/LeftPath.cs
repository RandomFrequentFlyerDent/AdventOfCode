using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Circuitry.Paths
{
    public class LeftPath : IPath
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        public int PathLength { get; }

        public LeftPath(Point startPoint, int length)
        {
            StartPoint = startPoint;
            EndPoint = new Point(startPoint.X - length, startPoint.Y);
            PathLength = length;
        }

        public List<Point> Get()
        {
            var points = new List<Point>();
            for (int i = StartPoint.X - 1; i >= EndPoint.X; i--)
            {
                var point = new Point(i, StartPoint.Y);
                points.Add(point);
            }
            return points;
        }

        public IEnumerable<int> GetDistanceRange()
        {
            return Enumerable.Range(EndPoint.X, PathLength).Reverse();
        }
    }
}
