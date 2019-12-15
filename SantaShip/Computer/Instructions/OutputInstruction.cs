namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private RetrieveParameter _first;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public OutputInstruction(InstructionCode instructionCode, int instructionPointer)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
        }

        public void Process(ref int[] memory) { }

        public int GetOutput(ref int[] memory)
        {
            return _first.GetValue(ref memory);
        }
    }
}
