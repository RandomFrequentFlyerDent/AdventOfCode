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
            var distance = command.Substring(1);

            if (Int32.TryParse(distance, out int numberOfMoves))
            {
                for (int i = 0; i < numberOfMoves; i++)
                {
                    var next = GetNextPoint(direction);
                    line.Add(next);
                    _last = next;
                }
            }

            return line;
        }

        private Point GetNextPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(_last.X, _last.Y + 1);
                case Direction.Down:
                    return new Point(_last.X, _last.Y - 1);
                case Direction.Left:
                    return new Point(_last.X - 1, _last.Y);
                case Direction.Right:
                    return new Point(_last.X + 1, _last.Y);
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
    }
}
