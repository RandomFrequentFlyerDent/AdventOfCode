using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class JumpIfFalseInstruction : IInstruction
    {
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        public int NumberOfUsedMemorySlots { get; }

        public JumpIfFalseInstruction(InstructionCode instructionCode)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, IntCodeComputer.InstructionPointer + 2);
        }

        public void Process(ref int[] memory)
        {
            if (_first.GetValue(ref memory) == 0)
            {
                IntCodeComputer.InstructionPointer = _second.GetValue(ref memory);
            }
            else
            {
                IntCodeComputer.InstructionPointer += 3;
            }
        }
    }
}
