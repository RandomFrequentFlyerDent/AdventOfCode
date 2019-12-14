using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Circuitry
{
    public class CircuitBoard
    {
        private readonly List<Wire> _wires;
        private List<Point> _intersections;
        private Point _centralPort;

        public CircuitBoard(Point centralPort, List<Wire> wires)
        {
            _centralPort = centralPort;
            _wires = wires;
            _intersections = new List<Point>();
        }

        public int? GetDistanceToClosestIntersection(DistanceCaluclation typeOfCalculation)
        {
            DetermineIntersections();

            if (typeOfCalculation == DistanceCaluclation.Manhattan)
                return GetDistanceToClosestIntersectionByManhattan();

            if (typeOfCalculation == DistanceCaluclation.AlongTheWire)
                return GetDistanceToClosestIntersectionAlongTheWire();

            return null;
        }

        private int GetDistanceToClosestIntersectionByManhattan()
        { 
            var distance = int.MaxValue;
            foreach (var point in _intersections)
            {
                var manhattanDistance = Math.Abs(_centralPort.X + point.X) + Math.Abs(_centralPort.Y + point.Y);
                if (manhattanDistance < distance)
                    distance = manhattanDistance;
            }

            return distance;
        }

        private int GetDistanceToClosestIntersectionAlongTheWire()
        {
            var steps = int.MaxValue;
            foreach (var intersection in _intersections)
            {
                int combinedSteps = 0;
                foreach (var wire in _wires)
                {
                    combinedSteps += wire.GetDistanceToIntersection(intersection);
                }
                if (combinedSteps < steps)
                    steps = combinedSteps;
            }
            return steps;
        }

        private void DetermineIntersections()
        {
            var allWirePath = new List<Point>();

            foreach (var wire in _wires)
            {
                wire.DeterminePath();
                allWirePath.AddRange(GetUndoubledPath(wire.Path));
                wire.ResetPath();
            }

            _intersections = allWirePath
                .GroupBy(point => point)
                .Select(p => new { DistinctPoint = p.Key, PointCount = p.Count() })
                .Where(a => a.PointCount == _wires.Count)
                .Select(a => a.DistinctPoint)
                .ToList();
        }

        private List<Point> GetUndoubledPath(List<Point> path)
        {
            return path
                .GroupBy(point => point)
                .Select(p => new { DistinctPoint = p.Key, PointCount = p.Count() })
                .Where(a => a.PointCount == 1)
                .Select(a => a.DistinctPoint)
                .ToList();
        }
    }
}