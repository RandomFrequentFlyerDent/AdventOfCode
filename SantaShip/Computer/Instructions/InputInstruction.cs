﻿namespace SantaShip.Computer.Instructions
{
    public class InputInstruction : IInstruction
    {
        private int? _input;
        private StoreParameter _first;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public InputInstruction(InstructionCode instructionCode, int instructionPointer, int? input)
        {
            _input = input;
            _first = new StoreParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
        }

        public void Process(ref int[] memory)
        {
            _first.StoreValue(ref memory, _input);
        }
    }
}
