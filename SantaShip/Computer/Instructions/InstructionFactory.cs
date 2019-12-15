namespace SantaShip.Computer.Instructions

{
    public class InstructionFactory
    {
        public IInstruction CreateInstruction(int instructionCode, int instructionPointer, int? input = null)
        {
            var opCode = (OpCode)instructionCode;

            if (opCode == OpCode.Add)
                return new AdditionInstruction(instructionPointer);
            if (opCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionPointer);
            if (opCode == OpCode.Input)
                return new InputInstruction(instructionPointer, input);
            if (opCode == OpCode.Output)
                return new OutputInstruction(instructionPointer);

            return null;
        }

        private enum OpCode
        {
            Add = 1,
            Multiply = 2,
            Input = 3,
            Output = 4,
            Stop = 99
        }
    }

}
