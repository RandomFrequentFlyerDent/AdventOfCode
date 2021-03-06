﻿using NUnit.Framework;
using SantaShip;
using SantaShip.Computer;

namespace AdventOfCodeTests.SantaShipTests
{
    public class IntCodeComputerTests
    {
        // Program1: 1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2).
        [Test]
        public void ProcessProgram1()
        {
            var expected = new int[] { 2, 0, 0, 0, 99 };

            var input = new int[] { 1, 0, 0, 0, 99 };
            var program = new IntCodeComputer(input);

            program.Process();

            var actual = program.SoftwareProgram.Memory;

            Assert.AreEqual(expected, actual);
        }

        // Program2: 2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).
        [Test]
        public void ProcessProgram2()
        {
            var expected = new int[] { 2, 3, 0, 6, 99 };

            var input = new int[] { 2, 3, 0, 3, 99 };
            var program = new IntCodeComputer(input);

            program.Process();

            var actual = program.SoftwareProgram.Memory;

            Assert.AreEqual(expected, actual);
        }

        // Program3: 2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).
        [Test]
        public void ProcessProgram3()
        {
            var expected = new int[] { 2, 4, 4, 5, 99, 9801 };

            var input = new int[] { 2, 4, 4, 5, 99, 0 };
            var program = new IntCodeComputer(input);
            program.Process();

            var actual = program.SoftwareProgram.Memory;

            Assert.AreEqual(expected, actual);
        }

        // Program4: 1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.
        [Test]
        public void ProcessProgram4()
        {
            var expected = new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 };

            var input = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var program = new IntCodeComputer(input);

            program.Process();

            var actual = program.SoftwareProgram.Memory;

            Assert.AreEqual(expected, actual);
        }

        // Program5: 1,9,10,3,2,3,11,0,99,30,40,50 becomes 3500,9,10,70,2,3,11,0,99,30,40,50
        [Test]
        public void ProcessProgram5()
        {
            var expected = new int[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };

            var input = new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var program = new IntCodeComputer(input);

            program.Process();

            var actual = program.SoftwareProgram.Memory;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ProcessInputOutputProgram6()
        {
            var input = 50;

            var memory = new int[] { 3, 0, 4, 0, 99 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(input, output);
        }

        //3,9,8,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).
        [Test]
        public void OutputIsEqualToEightTrueProgramPositionMode()
        {
            var input = 8;

            var memory = new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(1, output);
        }

        [TestCase(7)]
        [TestCase(9)]
        [TestCase(88)]
        public void OutputIsEqualToEightFalseProgramPositionMode(int input)
        {
            var memory = new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(0, output);
        }

        //3,9,7,9,10,9,4,9,99,-1,8 - Using position mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(7)]
        public void OutputIsLessThanEightTrueProgramPositionMode(int input)
        {
            var memory = new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(1, output);
        }

        [TestCase(8)]
        [TestCase(9)]
        [TestCase(88)]
        public void OutputIsLessThanEightFalseProgramPositionMode(int input)
        {
            var memory = new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(0, output);
        }

        //3,3,1108,-1,8,3,4,3,99 - Using immediate mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).
        [Test]
        public void OutputIsEqualToEightTrueProgramImmediateMode()
        {
            var input = 8;

            var memory = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(1, output);
        }

        [TestCase(7)]
        [TestCase(9)]
        [TestCase(88)]
        public void OutputIsEqualToEightFalseProgramImmediateMode(int input)
        {
            var memory = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(0, output);
        }

        //3,3,1107,-1,8,3,4,3,99 - Using immediate mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(7)]
        public void OutputIsLessThanEightTrueProgramImmediateMode(int input)
        {
            var memory = new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(1, output);
        }

        [TestCase(8)]
        [TestCase(9)]
        [TestCase(88)]
        public void OutputIsLessThanEightFalseProgramImmediatenMode(int input)
        {
            var memory = new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var program = new IntCodeComputer(memory)
            {
                Input = input
            };
            program.Process();

            var output = program.Output;

            Assert.AreEqual(0, output);
        }

        // 109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 takes no input and produces a copy of itself as output.
        [Test]
        public void ProducesCopyOfItself()
        {
            var memory = new int[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            var program = new IntCodeComputer(memory);
            program.Process();

            var error = program.ErrorProgram.Memory;

            Assert.AreEqual(memory, error);
        }

        // 1102,34915192,34915192,7,4,7,99,0 should output a 16-digit number
        [Test]
        public void Produces16DigitNumber()
        {
            var memory = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var program = new IntCodeComputer(memory);
            program.Process();

            var output = program.Output;

            Assert.IsTrue(output.ToString().Length == 16);
            Assert.AreEqual(1219070632396864, output);
        }

        // 104,1125899906842624,99 should output the large number in the middle
        [Test]
        public void ProducesLargeNumber()
        {
            var memory = new long[] { 104, 1125899906842624, 99 };
            var program = new IntCodeComputer(memory);
            program.Process();

            var output = program.Output;

            Assert.AreEqual(1125899906842624, output);
        }
    }
}
