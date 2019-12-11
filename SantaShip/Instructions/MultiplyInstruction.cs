namespace SantaShip.Instructions
{
    /** From  the instruction pointer multiplies the values on the position given by the first
     * and second parameter and places the result in the position given in the third parameter **/
    public class MultiplyInstruction : IInstruction
    {
        private int _firstParameter;
        private int _secondParameter;
        private int _resultPosition;
        public int NumberOfUsedMemorySlots { get { return 4; } }

        public MultiplyInstruction(int instructionPointer)
        {
            _firstParameter = instructionPointer + 1;
            _secondParameter = instructionPointer + 2;
            _resultPosition = instructionPointer + 3;
        }

        public void Process(ref int[] memory)
        {
            if (_resultPosition <= memory.Length)
            {
                int leftValue = memory[memory[_firstParameter]];
                int rightValue = memory[memory[_secondParameter]];

                memory[memory[_resultPosition]] = leftValue * rightValue;
            }
        }
    }
}
