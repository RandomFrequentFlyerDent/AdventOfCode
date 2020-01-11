using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class AdditionInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public AdditionInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3, relativeBase);
        }

        public int Process(ref int[] memory)
        {
            if (_third.Position <= memory.Length)
            {
                int firstValue = _first.GetValue(ref memory);
                int secondValue = _second.GetValue(ref memory);
                _third.StoreValue(ref memory, firstValue + secondValue);
            }
            return _instructionPointer + 4;
        }
    }
}
