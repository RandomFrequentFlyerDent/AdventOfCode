using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class EqualsInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public EqualsInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3, relativeBase);
        }

        public int Process(ref int[] memory)
        {
            int firstValue = _first.GetValue(ref memory);
            int secondValue = _second.GetValue(ref memory);
            if (firstValue == secondValue)
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
