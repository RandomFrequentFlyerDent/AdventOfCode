using DayOne;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Answer Day One Answer One: {GetDayOneAnswerOne()}");
            Console.WriteLine($"Answer Day One Answer Two: {GetDayOneAnswerTwo()}");
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
