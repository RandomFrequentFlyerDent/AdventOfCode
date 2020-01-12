using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class AdditionInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly RetrieveParameter _firstRetrieve;
        private readonly RetrieveParameter _secondRetrieve;
        private readonly StoreParameter _thirdStore;

        public AdditionInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase)
        {
            _instructionPointer = instructionPointer;
            _firstRetrieve = new RetrieveParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
            _secondRetrieve = new RetrieveParameter(instructionCode.SecondParameterMode, instructionPointer + 2, relativeBase);
            _thirdStore = new StoreParameter(instructionCode.ThirdParameterMode, instructionPointer + 3, relativeBase);
        }

        public void Process(SoftwareProgram memory)
        {
            long firstValue = _firstRetrieve.GetValue(ref memory);
            long secondValue = _secondRetrieve.GetValue(ref memory);
            _thirdStore.StoreValue(ref memory, firstValue + secondValue);
        }

        public int MoveInstructionPointer()
        {
            return _instructionPointer + 4;
        }
    }
}
