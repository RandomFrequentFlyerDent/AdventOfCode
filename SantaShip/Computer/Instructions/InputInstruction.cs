using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class InputInstruction : IInstruction
    {
        private readonly int? _input;
        private readonly StoreParameter _first;
        public int NumberOfUsedMemorySlots { get { return 2; } }

        public InputInstruction(InstructionCode instructionCode, int? input)
        {
            _input = input;
            _first = new StoreParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
        }

        public void Process(ref int[] memory)
        {
            _first.StoreValue(ref memory, _input);
        }
    }
}
