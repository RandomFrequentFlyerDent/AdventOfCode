using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Circuitry.Paths
{
    public static class PathExtensions
    {
        public static bool IsOnPath(this IPath path, Point intersection, out Point reachedPoint, out int distance)
        {
            var range = path.GetDistanceRange().ToList();
            reachedPoint = path.EndPoint;
            distance = path.PathLength;

            if (IsOnXAndY(path, range, intersection))
            {
                distance = GetDistanceToIntersection(path, range, intersection);
                return true;
            }

            return false;
        }

        private static bool IsOnXAndY(IPath path, List<int> range, Point intersection)
        {
            var onX = false;
            var onY = false;

            if (path is RightPath || path is LeftPath)
            {
                onX = range.Contains(intersection.X);
                onY = path.EndPoint.Y == intersection.Y;
            }

            if (path is UpPath || path is DownPath)
            {
                onX = range.Contains(intersection.Y);
                onY = path.EndPoint.X == intersection.X;
            }

            return onX && onY;
        }

        private static int GetDistanceToIntersection(IPath path, List<int> range, Point intersection)
        {
            if (path is RightPath)
                return range.IndexOf(intersection.X);

            if (path is UpPath)
                return range.IndexOf(intersection.Y);

            if (path is LeftPath)
                return range.IndexOf(intersection.X) + 1;

            if (path is DownPath)
                return range.IndexOf(intersection.Y) + 1;

            return int.MaxValue;
        }
    }
}
