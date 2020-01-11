using SantaShip.Computer.Instructions;
using System.Collections.Generic;

namespace SantaShip.Computer
{
    public class IntCodeComputer : IOutputReceiver
    {
        public int InstructionPointer { get; set; }
        public int RelativeBase { get; set; }

        private int[] _memory;
        public int[] Memory { get { return _memory; } }

        private Queue<int> _input;
        public int Input { set { _input.Enqueue(value); } }
        public int Output { get; private set; }

        public bool HasStopped { get; private set; }

        public IOutputReceiver OutputReceiver { get; set; }

        public IntCodeComputer(int[] memory)
        {
            _memory = memory;
            InstructionPointer = 0;
            RelativeBase = 0;
            _input = new Queue<int>();
        }

        public void SetNoun(int noun)
        {
            _memory[1] = noun;
        }

        public void SetVerb(int verb)
        {
            _memory[2] = verb;
        }

        public void Process()
        {
            var instructionFactory = new InstructionFactory(_input);
            var lengthOfMemory = _memory.Length;
            var reading = true;

            do
            {
                var opCode = _memory[InstructionPointer];
                IInstruction instruction = instructionFactory.CreateInstruction(opCode, InstructionPointer, RelativeBase);
                if (instruction != null)
                {
                    if (instruction is StopInstruction)
                    {
                        reading = false;
                        HasStopped = true;
                    }
                    else if (instruction is OutputInstruction)
                    {
                        Output = ((OutputInstruction)instruction).GetOutput(ref _memory);
                        if (OutputReceiver != null)
                        {
                            OutputReceiver.ReceiveInput(Output);
                        }
                        InstructionPointer = instruction.Process(ref _memory);
                        reading = false;
                    }
                    else
                    {
                        InstructionPointer = instruction.Process(ref _memory);
                    }
                }
                else
                {
                    reading = false;
                }

            } while (reading && InstructionPointer < lengthOfMemory);
        }

        public int RetrieveValueFromMemory(int address)
        {
            return _memory[address];
        }

        public void ReceiveInput(int input)
        {
            _input.Enqueue(input);
        }
    }
}
