using DayFour;
using DayThree;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var santaShip = new SantaShip();

            santaShip.ModuleInformation.DetermineTotalFuelRequirement();
        }

        private static async Task<int> GetDayFourAnswer(bool isQuestionTwo)
        {
            var possiblePasswords = 0;
            var range = Enumerable.Range(372037, 905158 - 372037);
            var tasks = new List<Task<bool>>();

            foreach (var number in range)
            {
                tasks.Add(PasswordChecker.IsValid(number, 372037, 905157, isQuestionTwo));
            }

            foreach (var task in await Task.WhenAll(tasks))
            {
                if(task)
                    possiblePasswords++;
            }

            return possiblePasswords;
        }

        private static int GetDayThreeAnswerTwo()
        {
            var wireOne = new WireOne();
            var wireTwo = new WireTwo();
            var centralPort = new Point(0, 0);
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            return crossedWires.GetClosestDistanceToCentralPortBySteps();
        }

        private static int GetDayThreeAnswerOne()
        {
            var wireOne = new WireOne();
            var wireTwo = new WireTwo();
            var centralPort = new Point(0, 0);
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            return crossedWires.GetClosestDistanceToCentralPortByManhattan();
        }
    }
}
