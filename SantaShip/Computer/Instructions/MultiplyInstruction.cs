using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    /** From  the instruction pointer multiplies the values on the position given by the first
     * and second parameter and places the result in the position given in the third parameter **/
    public class MultiplyInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public MultiplyInstruction(InstructionCode instructionCode, int instructionPointer)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3);
        }

        public int Process(ref int[] memory)
        {
            if (_third.Position <= memory.Length)
            {
                int firstValue = _first.GetValue(ref memory);
                int secondValue = _second.GetValue(ref memory);
                _third.StoreValue(ref memory, firstValue * secondValue);
            }
            return _instructionPointer + 4;
        }
    }
}
