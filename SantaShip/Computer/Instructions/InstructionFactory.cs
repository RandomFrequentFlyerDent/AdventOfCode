using System.Collections.Generic;

namespace SantaShip.Computer.Instructions

{
    public class InstructionFactory
    {
        private Queue<int> _inputQueue;

        public InstructionFactory(Queue<int> input)
        {
            _inputQueue = input;
        }

        public IInstruction CreateInstruction(int code, int instructionPointer)
        {
            var instructionCode = new InstructionCode(code.ToString());

            if (instructionCode.OpCode == OpCode.Add)
                return new AdditionInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Input)
                return new InputInstruction(instructionCode, instructionPointer, _inputQueue.Dequeue());
            if (instructionCode.OpCode == OpCode.Output)
                return new OutputInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.JumpIfTrue)
                return new JumpIfTrueInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.JumpIfFalse)
                return new JumpIfFalseInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.LessThan)
                return new LessThanInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Equals)
                return new EqualsInstruction(instructionCode, instructionPointer);
            if (instructionCode.OpCode == OpCode.Stop)
                return new StopInstruction();

            return null;
        }
    }
}
