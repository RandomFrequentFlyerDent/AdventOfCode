using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DayThree
{
    public class CrossedWires
    {
        private Point _centralPort;
        private Wire _wireOne;
        private Wire _wireTwo;
        private List<Point> _crossedWires;

        public CrossedWires(Wire wireOne, Wire wireTwo, Point centralPort)
        {
            _wireOne = wireOne;
            _wireTwo = wireTwo;
            _centralPort = centralPort;
        }

        public int GetClosestDistanceToCentralPort()
        {
            DetermineCrossedWires();

            var distance = int.MaxValue;
            foreach (var point in _crossedWires)
            {
                var manhattanDistance = Math.Abs(_centralPort.X + point.X) + Math.Abs(_centralPort.Y + point.Y);
                if (manhattanDistance < distance)
                    distance = manhattanDistance;
            }
            return distance;
        }

        private void DetermineCrossedWires()
        {
            _crossedWires = _wireOne.Line
                .Where(point => _wireTwo.Line.Contains(point))
                .ToList();
        }
    }
}
