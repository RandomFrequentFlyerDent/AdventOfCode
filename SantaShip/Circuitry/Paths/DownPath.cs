using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Circuitry.Paths
{
    public class DownPath : IPath
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public int PathLength { get; }

        public DownPath(Point startPoint, int length)
        {
            StartPoint = startPoint;
            EndPoint = new Point(startPoint.X, startPoint.Y - length);
            PathLength = length;
        }

        public List<Point> Get()
        {
            var points = new List<Point>();
            for (int i = StartPoint.Y - 1; i >= EndPoint.Y; i--)
            {
                var point = new Point(StartPoint.X, i);
                points.Add(point);
            }
            return points;
        }

        public IEnumerable<int> GetDistanceRange()
        {
            return Enumerable.Range(EndPoint.Y, PathLength).Reverse();
        }
    }
}
