using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;

        public OutputInstruction(InstructionCode instructionCode, int instructionPointer)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
        }

        public int Process(ref int[] memory)
        {
            return _instructionPointer + 2;
        }

        public int GetOutput(ref int[] memory)
        {
            var value = _first.GetValue(ref memory);
            return value;
        }
    }
}
