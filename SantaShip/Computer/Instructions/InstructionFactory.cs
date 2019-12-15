namespace SantaShip.Computer.Instructions

{
    public class InstructionFactory
    {
        public IInstruction CreateInstruction(int code, int? input = null)
        {
            var instructionCode = new InstructionCode(code.ToString());

            if (instructionCode.OpCode == OpCode.Add)
                return new AdditionInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.Input)
                return new InputInstruction(instructionCode, input);
            if (instructionCode.OpCode == OpCode.Output)
                return new OutputInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.JumpIfTrue)
                return new JumpIfTrueInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.JumpIfFalse)
                return new JumpIfFalseInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.LessThan)
                return new LessThanInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.Equals)
                return new EqualsInstruction(instructionCode);
            if (instructionCode.OpCode == OpCode.Stop)
                return new StopInstruction();

            return null;
        }
    }
}
