using SantaShip.Computer.Instructions.Parameters;

namespace SantaShip.Computer.Instructions
{
    public class InputInstruction : IInstruction
    {
        private readonly int _instructionPointer;
        private readonly long? _input;
        private readonly StoreParameter _first;

        public InputInstruction(InstructionCode instructionCode, int instructionPointer, int relativeBase, long? input)
        {
            _instructionPointer = instructionPointer;
            _input = input;
            _first = new StoreParameter(instructionCode.FirstParameterMode, instructionPointer + 1, relativeBase);
        }

        public void Process(SoftwareProgram memory)
        {
            _first.StoreValue(ref memory, _input);
        }

        public int MoveInstructionPointer()
        {
            return _instructionPointer + 2;
        }
    }
}
