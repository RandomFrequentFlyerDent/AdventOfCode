namespace SantaShip.Computer.Instructions
{
    public class InputInstruction : IInstruction
    {
        private int? _input;
        private int _firstParameter;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public InputInstruction(int instructionPointer, int? input)
        {
            _input = input;
            _firstParameter = instructionPointer + 1;
        }

        public void Process(ref int[] memory)
        {
            if (_input != null)
                memory[memory[_firstParameter]] = (int)_input;
        }
    }
}
