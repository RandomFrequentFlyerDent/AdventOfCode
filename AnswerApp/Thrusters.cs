﻿using SantaShip;
using SantaShip.Propulsion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnswerApp
{
    public class Thrusters
    {
        private int[] _amplifierControllerSoftware = new int[]
        {
            3,8,1001,8,10,8,105,1,0,0,21,42,55,64,85,98,179,260,341,422,99999,3,9,101,
            2,9,9,102,5,9,9,1001,9,2,9,1002,9,5,9,4,9,99,3,9,1001,9,5,9,1002,9,4,9,4,9,
            99,3,9,101,3,9,9,4,9,99,3,9,1002,9,4,9,101,3,9,9,102,5,9,9,101,4,9,9,4,9,99,
            3,9,1002,9,3,9,1001,9,3,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,
            1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,
            9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,
            2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,
            4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,
            3,9,101,2,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,
            9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,
            2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,102,2,9,
            9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,
            9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,99,
            3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,
            1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,
            2,9,9,4,9,3,9,102,2,9,9,4,9,99
        };

        /// <summary>
        /// Day 7 Answer 1 & 2
        /// </summary>
        public void GetHighestSignal(bool withFeedBackLoop)
        {
            var sequences = GetSequences(withFeedBackLoop);
            long highestSignal = long.MinValue;
            foreach (var sequence in sequences)
            {
                var signal = GetSignal(sequence, withFeedBackLoop);
                if (signal > highestSignal)
                    highestSignal = signal;
            }

            Console.WriteLine($"The highest signal that can be sent to the thrusters is {highestSignal}");
        }

        private List<int[]> GetSequences(bool withFeedBackLoop)
        {
            if (withFeedBackLoop)
                return PhaseSequenceGenerator.Generate(new int[] { 9, 8, 7, 6, 5 });
            return PhaseSequenceGenerator.Generate(new int[] { 0, 1, 2, 3, 4 });
        }

        private long GetSignal(int[] phaseSequence, bool withFeedBackLoop)
        {
            var computer = new AmplifierSystem(_amplifierControllerSoftware, phaseSequence);
            return computer.GetThrusterSignal();
        }
    }
}
