using DayTwo;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    public class DayTwoTests
    {
        // Program1: 1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2).
        [Test]
        public void ProcessProgram1()
        {
            var expected = new List<int> { 2, 0, 0, 0, 99 };

            var input = new List<int> { 1, 0, 0, 0, 99 };
            var program = new IntcodeProgram(input);

            var actual = program.Process();

            Assert.AreEqual(expected, actual);
        }

        // Program2: 2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).
        [Test]
        public void ProcessProgram2()
        {
            var expected = new List<int> { 2, 3, 0, 6, 99 };

            var input = new List<int> { 2, 3, 0, 3, 99 };
            var program = new IntcodeProgram(input);

            var actual = program.Process();

            Assert.AreEqual(expected, actual);
        }

        // Program3: 2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).
        [Test]
        public void ProcessProgram3()
        {
            var expected = new List<int> { 2, 4, 4, 5, 99, 9801 };

            var input = new List<int> { 2, 4, 4, 5, 99, 0 };
            var program = new IntcodeProgram(input);

            var actual = program.Process();

            Assert.AreEqual(expected, actual);
        }

        // Program4: 1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.
        [Test]
        public void ProcessProgram4()
        {
            var expected = new List<int> { 30, 1, 1, 4, 2, 5, 6, 0, 99 };

            var input = new List<int> { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var program = new IntcodeProgram(input);

            var actual = program.Process();

            Assert.AreEqual(expected, actual);
        }

        // Program5: 1,9,10,3,2,3,11,0,99,30,40,50 becomes 3500,9,10,70,2,3,11,0,99,30,40,50
        [Test]
        public void ProcessProgram5()
        {
            var expected = new List<int> { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };

            var input = new List<int> { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var program = new IntcodeProgram(input);

            var actual = program.Process();

            Assert.AreEqual(expected, actual);
        }
    }
}
