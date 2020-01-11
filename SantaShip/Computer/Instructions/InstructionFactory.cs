using System.Collections.Generic;

namespace SantaShip.Computer.Instructions

{
    public class InstructionFactory
    {
        private readonly Queue<int> _inputQueue;

        public InstructionFactory(Queue<int> input)
        {
            _inputQueue = input;
        }

        public IInstruction CreateInstruction(int code, int instructionPointer, int relativeBase)
        {
            var instructionCode = new InstructionCode(code.ToString());

            if (instructionCode.OpCode == OpCode.Add)
                return new AdditionInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.Multiply)
                return new MultiplyInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.Input)
                return new InputInstruction(instructionCode, instructionPointer, relativeBase, _inputQueue.Dequeue());
            if (instructionCode.OpCode == OpCode.Output)
                return new OutputInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.JumpIfTrue)
                return new JumpIfTrueInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.JumpIfFalse)
                return new JumpIfFalseInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.LessThan)
                return new LessThanInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.Equals)
                return new EqualsInstruction(instructionCode, instructionPointer, relativeBase);
            if (instructionCode.OpCode == OpCode.Stop)
                return new StopInstruction();

            return null;
        }
    }
}
