using System;
using System.Collections.Generic;
using System.Drawing;

namespace DayThree
{
    public abstract class Wire
    {
        public virtual List<Point> Line { get { return _line; } }
        private List<Point> _line = new List<Point>();
        public virtual List<string> Commands { get; }
        public Point CentralPort
        {
            get { return _centralPort; }
            set { _centralPort = value; }
        }
        private Point _centralPort;
        private Point _last;

        public int GetNumberOfStepsToIntersection(Point intersection)
        {
            var lastPoint = new Point(0, 0);
            var steps = 0;
            bool done = false;

            foreach (var command in Commands)
            {
                var direction = GetDirection(command[0]);
                var numberOfSteps = GetNumberOfSteps(command);

                for (int i = 0; i < numberOfSteps; i++)
                {
                    steps++;
                    var next = GetNextPoint(direction, lastPoint);
                    if (!next.Equals(intersection))
                    {
                        lastPoint = next;
                    }
                    else
                    {
                        done = true;
                        break;
                    }
                }

                if (done)
                    break;
            }

            if (!done)
                throw new Exception($"Intersection ({intersection.X},{intersection.Y}) not on wire");

            return steps;
        }

        protected void DrawLine()
        {
            _last = CentralPort;

            foreach (var command in Commands)
            {
                _line.AddRange(GetNextLine(command));
            }
        }

        private List<Point> GetNextLine(string command)
        {
            var line = new List<Point>();
            var direction = GetDirection(command[0]);
            var numberOfSteps = GetNumberOfSteps(command);

            for (int i = 0; i < numberOfSteps; i++)
            {
                var next = GetNextPoint(direction, _last);
                line.Add(next);
                _last = next;
            }


            return line;
        }

        private Point GetNextPoint(Direction direction, Point lastPoint)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(lastPoint.X, lastPoint.Y + 1);
                case Direction.Down:
                    return new Point(lastPoint.X, lastPoint.Y - 1);
                case Direction.Left:
                    return new Point(lastPoint.X - 1, lastPoint.Y);
                case Direction.Right:
                    return new Point(lastPoint.X + 1, lastPoint.Y);
                default:
                    throw new Exception("Unknown direction");
            }

        }

        private Direction GetDirection(char direction)
        {
            switch (direction)
            {
                case 'U':
                    return Direction.Up;
                case 'D':
                    return Direction.Down;
                case 'L':
                    return Direction.Left;
                case 'R':
                    return Direction.Right;
                default:
                    throw new Exception($"Unknown direction: {direction}");
            }
        }

        private int GetNumberOfSteps(string command)
        {
            if (Int32.TryParse(command.Substring(1), out int numberOfSteps))
                return numberOfSteps;

            return 0;
        }
    }
}
