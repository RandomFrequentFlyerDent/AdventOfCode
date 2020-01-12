using SantaShip.Computer.Instructions.Parameters;
using System;

namespace SantaShip.Computer.Instructions
{
    public class RelativeBaseOffsetInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly int _relativeBase;
        private readonly RetrieveParameter _first;

        public RelativeBaseOffsetInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _relativeBase = relativeBase;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
        }

        public void Process(SoftwareProgram memory)
        {
            // no action required
        }

        public int MoveInstructionPointer()
        {
            return _instructionPointer + 2;
        }

        public int GetRelativeBase(ref SoftwareProgram memory)
        {
            var value = _first.GetValue(ref memory);
            return _relativeBase + Convert.ToInt32(value);
        }
    }
}
