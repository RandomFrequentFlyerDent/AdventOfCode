using SantaShip.Computer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaShip.Computer
{
    public class IntCodeComputer : IOutputReceiver
    {
        public int InstructionPointer { get; set; }
        public int RelativeBase { get; set; }

        private SoftwareProgram softwareProgram;
        public SoftwareProgram SoftwareProgram { get { return softwareProgram; } }
        public SoftwareProgram ErrorProgram { get; private set; }

        private Queue<long> _input;
        public long Input { set { _input.Enqueue(value); } }
        public long Output { get; private set; }

        public bool HasStopped { get; private set; }
        private bool _outputReceiverIsSelf;

        public IOutputReceiver OutputReceiver { get; set; }

        public IntCodeComputer(int[] memory) : this(memory.Select(i => (long)i).ToArray()) { }
        public IntCodeComputer(long[] memory, bool outputReceiverIsSelf = false)
        {
            softwareProgram = new SoftwareProgram(memory);
            InstructionPointer = 0;
            RelativeBase = 0;
            _input = new Queue<long>();
            _outputReceiverIsSelf = outputReceiverIsSelf;
        }

        public void SetNoun(int noun)
        {
            softwareProgram[1] = noun;
        }

        public void SetVerb(int verb)
        {
            softwareProgram[2] = verb;
        }

        public void Process()
        {
            var instructionFactory = new InstructionFactory(_input);
            var reading = true;
            List<long> errorProgram = new List<long>();

            do
            {
                var opCode = softwareProgram[InstructionPointer];
                IInstruction instruction = instructionFactory.CreateInstruction(opCode, InstructionPointer, RelativeBase);
                if (instruction != null)
                {
                    if (instruction is StopInstruction)
                    {
                        if (errorProgram.Count > 0 && errorProgram[0] != Output)
                            ErrorProgram = new SoftwareProgram(errorProgram.ToArray());

                        reading = false;
                        HasStopped = true;
                    }
                    else if (instruction is RelativeBaseOffsetInstruction)
                    {
                        RelativeBase = ((RelativeBaseOffsetInstruction)instruction).GetRelativeBase(ref softwareProgram);
                    }
                    else if (instruction is OutputInstruction)
                    {
                        Output = ((OutputInstruction)instruction).GetOutput(ref softwareProgram);
                        if (OutputReceiver != null)
                        {
                            OutputReceiver.ReceiveInput(Output);
                            reading = false;
                        }
                        else if (_outputReceiverIsSelf)
                        {
                            reading = false;
                        }
                        else
                        {
                            errorProgram.Add(Output);
                        }
                    }
                    else
                    {
                        softwareProgram.ProcessInstruction(instruction);
                    }
                    InstructionPointer = instruction.MoveInstructionPointer();
                }
                else
                {
                    reading = false;
                }

            } while (reading && InstructionPointer < SoftwareProgram.Length);
        }

        public int RetrieveValueFromMemory(int address)
        {
            return Convert.ToInt32(softwareProgram[address]);
        }

        public void ReceiveInput(long input)
        {
            _input.Enqueue(input);
        }
    }
}
