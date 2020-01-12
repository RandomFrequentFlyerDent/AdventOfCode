using SantaShip.Computer.Instructions.Parameters;
using System;

namespace SantaShip.Computer.Instructions
{
    public class JumpIfTrueInstruction : IInstruction
    {
        private int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;

        public JumpIfTrueInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
        }

        public void Process(SoftwareProgram memory)
        {
            if (_first.GetValue(ref memory) != 0)
            {
                _instructionPointer = Convert.ToInt32(_second.GetValue(ref memory));
            }
            else
            {
                _instructionPointer += 3;
            }
        }

        public int MoveInstructionPointer()
        {
            return _instructionPointer;
        }
    }
}
