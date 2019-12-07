using System.Collections.Generic;

namespace DayTwo
{
    public class IntcodeProgram
    {
        private List<int> _memory;
        private int _instructionPointer;
        private int _lengthProgram;
        private OpCode? _opCode;

        public IntcodeProgram(List<int> memory)
        {
            _memory = memory;
            _lengthProgram = memory.Count;
            _instructionPointer = 0;
            _opCode = ReadOpCode();
        }

        public List<int> Process()
        {
            while(_opCode != OpCode.Stop && _instructionPointer < _lengthProgram)
            {
                if(_opCode == null)
                    throw new System.Exception("Unrecognized OpCode");

                if (_opCode == OpCode.Add)
                {
                    Add();
                }
                else if(_opCode == OpCode.Multiply)
                {
                    Multiply();
                }
                
                Update();
            }

            return _memory;
        }

        private OpCode ReadOpCode()
        {
            return (OpCode)_memory[_instructionPointer];
        }

        private void Add()
        {
            var updatePosition = _memory[_instructionPointer + 3];
            _memory[updatePosition] = GetValueForParameter(1) + GetValueForParameter(2);
        }

        private void Multiply()
        {
            var updatePosition = _memory[_instructionPointer + 3];
            _memory[updatePosition] = GetValueForParameter(1) * GetValueForParameter(2);
        }

        private int GetValueForParameter(int parameter)
        {
            var position = _memory[_instructionPointer + parameter];
            return _memory[position];
        }

        private void Update()
        {
            _instructionPointer += 4;
            _opCode = ReadOpCode();
        }
    }
}
