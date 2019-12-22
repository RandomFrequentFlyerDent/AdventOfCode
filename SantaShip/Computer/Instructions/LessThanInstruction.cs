using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class LessThanInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public LessThanInstruction(InstructionCode instructionCode, int instructionPointer)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3);
        }

        public int Process(ref int[] memory)
        {
            int firstValue = _first.GetValue(ref memory);
            int secondValue = _second.GetValue(ref memory);
            if (firstValue < secondValue)
            {
                _third.StoreValue(ref memory, 1);
            }
            else
            {
                _third.StoreValue(ref memory, 0);
            }
            return _instructionPointer + 4;
        }
    }
}
