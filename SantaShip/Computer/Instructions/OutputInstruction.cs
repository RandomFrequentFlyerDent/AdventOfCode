using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private readonly RetrieveParameter _first;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public OutputInstruction(InstructionCode instructionCode)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
        }

        public void Process(ref int[] memory) { }

        public int GetOutput(ref int[] memory)
        {
            return _first.GetValue(ref memory);
        }
    }
}
