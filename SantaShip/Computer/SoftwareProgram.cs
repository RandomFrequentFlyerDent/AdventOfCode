using SantaShip.Computer.Instructions;
using System;

namespace SantaShip.Computer
{
    public class SoftwareProgram
    {
        public long[] Memory { get { return _memory; } }
        private long[] _memory;

        public SoftwareProgram(long[] memory)
        {
            _memory = memory;
        }

        public int Length { get { return _memory.Length; } }

        public long this[int index]
        {
            get
            {
                if (index >= _memory.Length)
                {
                    Array.Resize(ref _memory, index + 1);
                }
                return _memory[index];
            }
            set
            {
                if (index >= _memory.Length)
                {
                    Array.Resize(ref _memory, index + 1);
                }
                _memory[index] = value;
            }
        }

        public int GetOpCode(int instructionPointer)
        {
            var value = _memory[instructionPointer];
            return Convert.ToInt32(value);
        }

        public void ProcessInstruction(IInstruction instruction)
        {
            instruction.Process(this);
        }
    }
}
