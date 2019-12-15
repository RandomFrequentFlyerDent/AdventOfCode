using SantaShip.Computer.Instructions.Paramters;

namespace SantaShip.Computer.Instructions
{
    public class OutputInstruction : IInstruction
    {
        private readonly RetrieveParameter _first;

        public OutputInstruction(InstructionCode instructionCode)
        {
            _first = new RetrieveParameter(instructionCode.FirstParameterMode, IntCodeComputer.InstructionPointer + 1);
        }

        public void Process(ref int[] memory) { }

        public int GetOutput(ref int[] memory)
        {
            var value = _first.GetValue(ref memory);
            IntCodeComputer.InstructionPointer += 2;
            return value;
        }
    }
}
