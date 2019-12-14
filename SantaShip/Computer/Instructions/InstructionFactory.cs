namespace SantaShip.Instructions
{
    public class InstructionFactory
    {
        public IInstruction CreateInstruction(int instructionCode, int instructionPointer)
        {
            var opCode = (OpCode)instructionCode;

            if (opCode == OpCode.Add)
                return new AdditionInstruction(instructionPointer);
            if (opCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionPointer);

            return null;
        }

        private enum OpCode
        {
            Add = 1,
            Multiply = 2,
            Stop = 99
        }
    }

}
