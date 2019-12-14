using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Circuitry.Paths
{
    public class RightPath : IPath
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public int PathLength { get; }

        public RightPath(Point startPoint, int length)
        {
            StartPoint = startPoint;
            EndPoint = new Point(startPoint.X + length, startPoint.Y);
            PathLength = length;
        }

        public List<Point> Get()
        {
            var points = new List<Point>();
            for (int i = StartPoint.X + 1; i <= EndPoint.X; i++)
            {
                var point = new Point(i, StartPoint.Y);
                points.Add(point);
            }
            return points;
        }

        public IEnumerable<int> GetDistanceRange()
        {
            return Enumerable.Range(StartPoint.X, PathLength);
        }
    }
}
