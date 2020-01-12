using SantaShip.Computer;
using System;

namespace AnswerApp.IntCodePrograms
{
    public class GravityAssistProgram
    {
        private readonly int[] _originalMemory = new int[]
            {
                1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,23,6,27,2,9,27,31,1,5,
                31,35,1,35,10,39,1,39,10,43,2,43,9,47,1,6,47,51,2,51,6,55,1,5,55,59,2,59,
                10,63,1,9,63,67,1,9,67,71,2,71,6,75,1,5,75,79,1,5,79,83,1,9,83,87,2,87,10,
                91,2,10,91,95,1,95,9,99,2,99,9,103,2,10,103,107,2,9,107,111,1,111,5,115,1,
                115,2,119,1,119,6,0,99,2,0,14,0
            };

        private IntCodeComputer _computer;

        public GravityAssistProgram()
        {
            _computer = new IntCodeComputer((int[])_originalMemory.Clone());
        }

        /// <summary>
        /// Day Two Answer One
        /// </summary>
        public void Restore()
        {
            _computer.SetNoun(12);
            _computer.SetVerb(2);
            _computer.Process();
            Console.WriteLine($"Value of memory at address 0 of the Gravity Assist is {_computer.RetrieveValueFromMemory(0)}");
        }

        /// <summary>
        /// Day Two Answer Two
        /// </summary>
        public void Activate(int requiredOutput)
        {
            bool outputReached = false;
            int noun = -1;
            int verb = -1;

            for (int n = 0; n < 100; n++)
            {
                noun = n;

                for (int v = 0; v < 100; v++)
                {
                    verb = v;
                    Reset();
                    _computer.SetNoun(n);
                    _computer.SetVerb(v);
                    _computer.Process();
                    int output = _computer.RetrieveValueFromMemory(0);
                    if (output == requiredOutput)
                    {
                        outputReached = true;
                        break;
                    }
                }

                if (outputReached)
                    break;
            }

            Console.WriteLine($"Gravity Assist for output {requiredOutput} produces {100 * noun + verb} with noun {noun} and verb {verb}");
        }

        private void Reset()
        {
            _computer = new IntCodeComputer((int[])_originalMemory.Clone());
        }
    }
}
