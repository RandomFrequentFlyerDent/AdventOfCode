using DayFour;
using DayOne;
using DayThree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var santaShip = new SantaShip();

            santaShip.GravityAssist.Restore();
            santaShip.GravityAssist.Activate(19690720);
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

        private static List<int> GetOriginalGravityAssistProgram()
        {
            return new List<int>
            {
                1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,23,6,27,2,9,27,31,1,5,
                31,35,1,35,10,39,1,39,10,43,2,43,9,47,1,6,47,51,2,51,6,55,1,5,55,59,2,59,
                10,63,1,9,63,67,1,9,67,71,2,71,6,75,1,5,75,79,1,5,79,83,1,9,83,87,2,87,10,
                91,2,10,91,95,1,95,9,99,2,99,9,103,2,10,103,107,2,9,107,111,1,111,5,115,1,
                115,2,119,1,119,6,0,99,2,0,14,0
            };
        }

        private static long GetDayOneAnswerTwo()
        {
            long requiredFuel = 0;
            var moduleMasses = GetModuleMasses();
            foreach (var mass in moduleMasses)
            {
                requiredFuel += FuelCalculator.CalculateAllTheFuelRequirements(mass);
            }

            return requiredFuel;
        }

        static long GetDayOneAnswerOne()
        {
            long requiredFuel = 0;
            var moduleMasses = GetModuleMasses();
            foreach (var mass in moduleMasses)
            {
                requiredFuel += FuelCalculator.CalculateFuelRequirement(mass);
            }

            return requiredFuel;
        }

        static List<long> GetModuleMasses()
        {
            var moduleMasses = new List<long>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AnswerApp.input.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (Int64.TryParse(line, out long result))
                        moduleMasses.Add(result);
                }
            }

            return moduleMasses;
        }
    }
}
