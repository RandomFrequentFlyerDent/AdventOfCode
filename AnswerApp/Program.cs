using DayFour;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var santaShip = new SantaShip();

            santaShip.Circuitry.GetDistanceFromCentralPortToClosestIntersectionAlongTheWire();
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
    }
}
