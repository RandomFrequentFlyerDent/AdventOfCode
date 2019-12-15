namespace SantaShip.Computer.Instructions

{
    public class InstructionFactory
    {
        public IInstruction CreateInstruction(int code, int instructionPointer, int? input = null)
        {
            var instructionCode = new InstructionCode(code.ToString());

            if (instructionCode.OpCode == OpCode.Add)
                return new AdditionInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Input)
                return new InputInstruction(instructionCode, instructionPointer, input);
            if (instructionCode.OpCode == OpCode.Output)
                return new OutputInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Stop)
                return new StopInstruction();

            return null;
        }
    }
}
