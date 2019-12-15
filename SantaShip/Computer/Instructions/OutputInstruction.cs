namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private int _firstParameter;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public OutputInstruction(int instructionPointer)
        {
            _firstParameter = instructionPointer + 1;
        }

        public void Process(ref int[] memory) { }

        public int GetOutput(ref int[] memory)
        {
            return memory[memory[_firstParameter]];
        }
    }
}
