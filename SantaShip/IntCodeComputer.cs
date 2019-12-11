﻿using SantaShip.Instructions;

namespace SantaShip
{
    public class IntCodeComputer
    {
        public int[] Memory { get { return _memory; } }
        private int[] _memory;

        public IntCodeComputer(int[] memory)
        {
            _memory = memory;
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

            var instructionFactory = new InstructionFactory();
            var instructionPointer = 0;
            var lengthOfMemory = _memory.Length;
            var reading = true;

            do
            {
                var opCode = _memory[instructionPointer];
                IInstruction instruction = instructionFactory.CreateInstruction(opCode, instructionPointer);
                if (instruction != null)
                {
                    instruction.Process(ref _memory);
                    instructionPointer += instruction.NumberOfUsedMemorySlots;
                }
                else
                {
                    reading = false;
                }

            } while (reading && instructionPointer < lengthOfMemory);
        }

        public int RetrieveValueFromMemory(int address)
        {
            return _memory[address];
        }
    }
}
