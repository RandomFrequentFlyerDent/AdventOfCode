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
        private List<Point> _intersections;

        public CrossedWires(Wire wireOne, Wire wireTwo, Point centralPort)
        {
            _wireOne = wireOne;
            _wireTwo = wireTwo;
            _centralPort = centralPort;
        }

        public int GetClosestDistanceToCentralPortBySteps()
        {
            DetermineIntersections();

            var steps = int.MaxValue;
            foreach (var intersection in _intersections)
            {
                var stepsWireOne = _wireOne.GetNumberOfStepsToIntersection(intersection);
                var stepsWireTwo = _wireTwo.GetNumberOfStepsToIntersection(intersection);
                var combinedSteps = stepsWireOne + stepsWireTwo;
                if (combinedSteps < steps)
                    steps = combinedSteps;
            }
            return steps;
        }

        public int GetClosestDistanceToCentralPortByManhattan()
        {
            DetermineIntersections();

            var distance = int.MaxValue;
            foreach (var point in _intersections)
            {
                var manhattanDistance = Math.Abs(_centralPort.X + point.X) + Math.Abs(_centralPort.Y + point.Y);
                if (manhattanDistance < distance)
                    distance = manhattanDistance;
            }
            return distance;
        }

        private void DetermineIntersections()
        {
            _intersections = _wireOne.Line
                .Where(point => _wireTwo.Line.Contains(point))
                .ToList();
        }
    }
}
