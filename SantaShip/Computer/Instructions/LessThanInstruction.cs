using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class LessThanInstruction : IInstruction
    {
        private readonly RetrieveParameter _first;
        private readonly RetrieveParameter _second;
        private readonly StoreParameter _third;

        public LessThanInstruction(InstructionCode instructionCode)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
            _second = new RetrieveParameter(instructionCode.SecondParameterMode, IntCodeComputer.InstructionPointer + 2);
            _third = new StoreParameter(instructionCode.ThirdParameterMode, IntCodeComputer.InstructionPointer + 3);
        }

        public void Process(ref int[] memory)
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
            IntCodeComputer.InstructionPointer += 4;
        }
    }
}
