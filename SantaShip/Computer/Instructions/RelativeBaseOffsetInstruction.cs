using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class RelativeBaseOffsetInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;

        public RelativeBaseOffsetInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
        }

        public int Process(ref int[] memory)
        {
            return _instructionPointer + 2;
        }

        public int GetRelativeBase(ref int[] memory)
        {
            var value = _first.GetValue(ref memory);
            return value;
        }
    }
}
