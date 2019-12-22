using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class JumpIfFalseInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        public int NumberOfUsedMemorySlots { get; }

        public JumpIfFalseInstruction(InstructionCode instructionCode, int instructionPointer)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2);
        }

        public int Process(ref int[] memory)
        {
            if (_first.GetValue(ref memory) == 0)
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
