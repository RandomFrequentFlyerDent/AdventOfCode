using SantaShip;
using System;
using System.Linq;

namespace AnswerApp
{
    public class VenusFuelContainer
    {
        private readonly SecureContainer _secureContainer;

        public VenusFuelContainer()
        {
            _secureContainer = new SecureContainer();
        }

        /// <summary>
        /// Day 4 Answer 1 and 2
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <param name="maxTwoAdjacent"></param>
        internal void GetNumberOfValidPasswords(int startRange, int endRange, bool maxTwoAdjacent)
        {
            var possiblePasswords = 0;
            var range = Enumerable.Range(startRange, (endRange + 1) - startRange - 1);

            foreach (var password in range)
            {
                if (_secureContainer.IsValid(password, maxTwoAdjacent))
                    possiblePasswords++;
            }

            if (maxTwoAdjacent)
            {
                Console.WriteLine($"The number of possible password, with max two adjacent numbers the same, in this range is {possiblePasswords}");
            }
            else
            {
                Console.WriteLine($"The number of possible passwords in this range is {possiblePasswords}");
            }
        }
    }
}
