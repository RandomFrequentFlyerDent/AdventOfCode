using SantaShip.Computer.Instructions.Parameters;
using System;

namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;

        public OutputInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
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

        public long GetOutput(ref SoftwareProgram memory)
        {
            return _first.GetValue(ref memory);
        }
    }
}
