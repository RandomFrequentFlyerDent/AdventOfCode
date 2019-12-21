using NUnit.Framework;
using SantaShip.Propulsion;
using System.Collections.Generic;

namespace AdventOfCodeTests.SantaShipTests
{
    public class PhaseSequenceGeneratorTests
    {
        [Test]
        public void OnePhaseInSequence()
        {
            var expected = new List<int[]> { new int[] { 1 } };
            var actual = PhaseSequenceGenerator.Generate(new int[] { 1 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoPhasesInSequence()
        {
            var expected = new List<int[]>
            {
                new int[] { 1, 2 },
                new int[] { 2, 1 }
            };
            var actual = PhaseSequenceGenerator.Generate(new int[] { 1, 2 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThreePhasesInSequence()
        {
            var expected = new List<int[]>
            {
                new int[] { 1, 2, 3 },
                new int[] { 1, 3, 2 },
                new int[] { 2, 1, 3 },
                new int[] { 2, 3, 1 },
                new int[] { 3, 1, 2 },
                new int[] { 3, 2, 1 }
            };
            var actual = PhaseSequenceGenerator.Generate(new int[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        //{1,2,3} {1,3,2} {2,1,3} {2,3,1} {3,1,2} {3,2,1}
    }
}
