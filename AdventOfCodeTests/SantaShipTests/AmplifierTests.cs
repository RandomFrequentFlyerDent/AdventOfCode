using NUnit.Framework;
using SantaShip.Propulsion;

namespace AdventOfCodeTests.SantaShipTests
{
    public class AmplifierTests
    {
        [Test]
        public void AmplifierProgram1()
        {
            var memory = new int[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 };
            var phaseSequence = new int[] { 4, 3, 2, 1, 0 };

            var amplifier = new Amplifiers(memory, phaseSequence);
            var actual = amplifier.GetThrusterSignal();
            var expected = 43210;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AmplifierProgram2()
        {
            var memory = new int[] 
            {
                3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23,
                99, 0, 0
            };
            var phaseSequence = new int[] { 0, 1, 2, 3, 4 };

            var amplifier = new Amplifiers(memory, phaseSequence);
            var actual = amplifier.GetThrusterSignal();
            var expected = 54321;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AmplifierProgram3()
        {
            var memory = new int[] 
            {
                3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33,
                1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0
            };
            var phaseSequence = new int[] { 1, 0, 4, 3, 2 };

            var amplifier = new Amplifiers(memory, phaseSequence);
            var actual = amplifier.GetThrusterSignal();
            var expected = 65210;

            Assert.AreEqual(expected, actual);
        }
    }
}
