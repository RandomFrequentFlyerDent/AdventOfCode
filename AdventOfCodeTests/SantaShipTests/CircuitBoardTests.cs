using NUnit.Framework;
using SantaShip.Circuitry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCodeTests.SantaShipTests
{
    public class CircuitBoardTests
    {
        // R8,U5,L5,D3 ~ U7,R6,D4,L4 = distance 6
        // R75,D30,R83,U83,L12,D49,R71,U7,L72 ~ U62,R66,U55,R34,D71,R55,D58,R83 = distance 159
        // R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51 ~ U98, R91, D20, R16, D67, R40, U7, R15, U6, R7 = distance 135

        private CircuitBoard CreateCircuitBoard(List<string> wire1, List<string> wire2)
        {
            var centralPort = new Point(0, 0);
            var wireOne = new Wire(wire1, centralPort);
            var wireTwo = new Wire(wire2, centralPort);

            return new CircuitBoard(centralPort, new List<Wire> { wireOne, wireTwo });
        }

        [Test]
        public void FindNearestIntersctionByManhattan1()
        {
            var wireOne = new List<string> { "R8", "U5", "L5", "D3" };
            var wireTwo = new List<string> { "U7", "R6", "D4", "L4" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 6;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.Manhattan);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestIntersectionByManhattan2()
        {
            var wireOne = new List<string> { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" };
            var wireTwo = new List<string> { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 159;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.Manhattan);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestIntersectionByManhattan3()
        {
            var wireOne = new List<string> { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" };
            var wireTwo = new List<string> { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 135;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.Manhattan);

            Assert.AreEqual(expected, actual);
        }

        // R8,U5,L5,D3 ~ U7,R6,D4,L4 = 30 steps
        // R75,D30,R83,U83,L12,D49,R71,U7,L72 ~ U62,R66,U55,R34,D71,R55,D58,R83 = 610 steps
        // R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51 ~ U98, R91, D20, R16, D67, R40, U7, R15, U6, R7 = 410 steps

        [Test]
        public void FindNearestIntersectionAlongTheWire1()
        {
            var wireOne = new List<string> { "R8", "U5", "L5", "D3" };
            var wireTwo = new List<string> { "U7", "R6", "D4", "L4" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 30;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.AlongTheWire);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestIntersectionAlongTheWire2()
        {
            var wireOne = new List<string> { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" };
            var wireTwo = new List<string> { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 610;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.AlongTheWire);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestIntersectionAlongTheWire3()
        {
            var wireOne = new List<string> { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" };
            var wireTwo = new List<string> { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" };
            var circuitBoard = CreateCircuitBoard(wireOne, wireTwo);
            var expected = 410;

            var actual = circuitBoard.GetDistanceToClosestIntersection(DistanceCaluclation.AlongTheWire);

            Assert.AreEqual(expected, actual);
        }
    }
}
