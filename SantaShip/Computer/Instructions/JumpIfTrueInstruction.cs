using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class JumpIfTrueInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        public int NumberOfUsedMemorySlots { get; }

        public JumpIfTrueInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
        }

        public int Process(ref int[] memory)
        {
            if (_first.GetValue(ref memory) != 0)
            {
                return _second.GetValue(ref memory);
            }
            else
            {
                return _instructionPointer + 3;
            }
        }
    }
}
