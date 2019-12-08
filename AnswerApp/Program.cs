﻿using DayOne;
using DayTwo;
using DayThree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Answer Day Two Answer Two: {GetDayThreeAnswerOne()}");
            // Console.WriteLine($"Answer Day Two Answer Two: {GetDayTwoAnswerTwo()}");
            // Console.WriteLine($"Answer Day Two Answer One: {GetDayTwoAnswerOne()}");
            // Console.WriteLine($"Answer Day One Answer Two: {GetDayOneAnswerTwo()}");
            // Console.WriteLine($"Answer Day One Answer One: {GetDayOneAnswerOne()}");
        }

        private static int GetDayThreeAnswerOne()
        {
            var wireOne = new WireOne();
            var wireTwo = new WireTwo();
            var centralPort = new Point(0, 0);
            var crossedWires = new CrossedWires(wireOne, wireTwo, centralPort);
            return crossedWires.GetClosestDistanceToCentralPort();
        }

        private static int GetDayTwoAnswerTwo()
        {
            bool done = false;
            int requiredOutput = 19690720;
            int noun = -1;
            int verb = -1;

            for (int i = 0; i < 100; i++)
            {
                noun = i;

                for (int y = 0; y < 100; y++)
                {
                    verb = y;
                    var memory = GetOriginalGravityAssistProgram();
                    memory[1] = noun;
                    memory[2] = verb;
                    var program = new IntcodeProgram(memory);
                    int output = program.Process()[0];
                    if(output == requiredOutput)
                    {
                        done = true;
                        break;
                    }
                }

                if (done)
                    break;
            }

            if (!done)
            {
                throw new Exception("Required output not found");
            }

            return 100 * noun + verb;
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

        private static int GetDayTwoAnswerOne()
        {
            var gravityAssistProgram = new IntcodeProgram(GetAdjustedGravityAssistProgram());
            var processed = gravityAssistProgram.Process();
            return processed[0];
        }

        private static List<int> GetAdjustedGravityAssistProgram()
        {
            return new List<int>
            {
                1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,23,6,27,2,9,27,31,1,5,
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
