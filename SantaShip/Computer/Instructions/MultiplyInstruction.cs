﻿using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class MultiplyInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public MultiplyInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3, relativeBase);
        }

        public void Process(SoftwareProgram memory)
        {
            long firstValue = _first.GetValue(ref memory);
            long secondValue = _second.GetValue(ref memory);
            _third.StoreValue(ref memory, firstValue * secondValue);
        }

        public int MoveInstructionPointer()
        {
            return _instructionPointer + 4;
        }
    }
}
