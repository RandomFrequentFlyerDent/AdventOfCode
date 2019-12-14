using SantaShip.Circuitry.Paths;
using System.Collections.Generic;
using System.Drawing;

namespace SantaShip.Circuitry
{
    public class Wire
    {
        private Point _centralPort;
        public List<Point> Path { get; private set; }
        private readonly List<string> _commands;

        public Wire(List<string> commands, Point centralPort)
        {
            _centralPort = centralPort;
            _commands = commands;
            Path = new List<Point>();
        }

        public void DeterminePath()
        {
            var commandFactory = new PathFactory();
            var lastPoint = _centralPort;
            foreach (var command in _commands)
            {
                var pathCommand = commandFactory.CreateCommand(command, lastPoint);
                var path = pathCommand.Get();
                lastPoint = pathCommand.EndPoint;

                Path.AddRange(path);
            }
        }

        public void ResetPath()
        {
            Path = new List<Point>();
        }

        public int GetDistanceToIntersection(Point intersection)
        {
            int distance = 0;
            var commandFactory = new PathFactory();
            var lastPoint = _centralPort;
            foreach (var command in _commands)
            {
                var pathCommand = commandFactory.CreateCommand(command, lastPoint);
                if (pathCommand.IsOnPath(intersection, out Point reachedPoint, out int distanceToIntersection))
                {
                    distance += distanceToIntersection;
                    return distance;
                }
                lastPoint = reachedPoint;
                distance += pathCommand.PathLength;
            }
            return distance;
        }
    }
}
