using NUnit.Framework;
using SantaShip.Navigation;
using System.Collections.Generic;

namespace AdventOfCodeTests.SantaShipTests
{
    public class NavigationTests
    {
        [Test]
        public void TotalNumberOfDirectAndIndirectOrbits()
        {
            var map = new List<string>
            {
                "COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L"
            };

            var universalOrbitMap = new UniversalOrbitMap(map);
            var total = universalOrbitMap.GetTotalNumberDirectAndIndirectOrbits();

            Assert.AreEqual(42, total);
        }
    }
}
