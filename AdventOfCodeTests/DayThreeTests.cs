using DayThree;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCodeTests
{
    public class DayThreeTests
    {
        // R8,U5,L5,D3 ~ U7,R6,D4,L4 = distance 6
        // R75,D30,R83,U83,L12,D49,R71,U7,L72 ~ U62,R66,U55,R34,D71,R55,D58,R83 = distance 159
        // R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51 ~ U98, R91, D20, R16, D67, R40, U7, R15, U6, R7 = distance 135


        [Test]
        public void FindNearestPort1()
        {
            var centralPort = new Point(0, 0);
            var wireOne = CreateWire(new List<string> { "R8", "U5", "L5", "D3" });
            var wireTwo = CreateWire(new List<string> { "U7", "R6", "D4", "L4" });
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            var expected = 6;

            var actual = crossedWires.GetClosestDistanceToCentralPort();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestPort2()
        {
            var centralPort = new Point(0, 0);
            var wireOne = CreateWire(new List<string> { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" });
            var wireTwo = CreateWire(new List<string> { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" });
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            var expected = 159;

            var actual = crossedWires.GetClosestDistanceToCentralPort();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNearestPort3()
        {
            var centralPort = new Point(0, 0);
            var wireOne = CreateWire(new List<string> { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" });
            var wireTwo = CreateWire(new List<string> { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" });
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            var expected = 135;

            var actual = crossedWires.GetClosestDistanceToCentralPort();

            Assert.AreEqual(expected, actual);
        }

        private Wire CreateWire(List<string> commands)
        {
            var wire = new TestWire(commands);
            wire.DrawTestLine();
            return wire;
        }
    }

    public class TestWire : Wire
    {
        public override List<string> Commands { get { return _commands; } }
        private List<string> _commands;

        public TestWire(List<string> commands)
        {
            _commands = commands;
        }

        public void DrawTestLine()
        {
            DrawLine();
        }
    }
}
