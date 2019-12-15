using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    /** From  the instruction pointer multiplies the values on the position given by the first
     * and second parameter and places the result in the position given in the third parameter **/
    public class MultiplyInstruction : IInstruction
    {
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public MultiplyInstruction(InstructionCode instructionCode)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, IntCodeComputer.InstructionPointer + 2);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, IntCodeComputer.InstructionPointer + 3);
        }

        public void Process(ref int[] memory)
        {
            if (_third.Position <= memory.Length)
            {
                int firstValue = _first.GetValue(ref memory);
                int secondValue = _second.GetValue(ref memory);
                _third.StoreValue(ref memory, firstValue * secondValue);
            }
            IntCodeComputer.InstructionPointer += 4;
        }
    }
}
