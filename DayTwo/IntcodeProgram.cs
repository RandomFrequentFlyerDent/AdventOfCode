using System.Collections.Generic;

namespace DayTwo
{
    public class IntcodeProgram
    {
        private List<int> _program;
        private int _nextPosition;
        private int _lengthProgram;
        private OpCode? _opCode;

        public IntcodeProgram(List<int> program)
        {
            _program = program;
            _lengthProgram = program.Count;
            _nextPosition = 0;
            _opCode = ReadOpCode();
        }

        public List<int> Process()
        {
            while(_opCode != OpCode.Stop && _nextPosition < _lengthProgram)
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

            return _program;
        }

        private OpCode ReadOpCode()
        {
            return (OpCode)_program[_nextPosition];
        }

        private void Add()
        {
            var leftPosition = _program[_nextPosition + 1];
            var leftValue = _program[leftPosition];
            var rightPosition = _program[_nextPosition + 2];
            var rightValue = _program[rightPosition];
            var updatePosition = _program[_nextPosition + 3];

            _program[updatePosition] = leftValue + rightValue;
        }

        private void Multiply()
        {
            var leftPosition = _program[_nextPosition + 1];
            var leftValue = _program[leftPosition];
            var rightPosition = _program[_nextPosition + 2];
            var rightValue = _program[rightPosition];
            var updatePosition = _program[_nextPosition + 3];

            _program[updatePosition] = leftValue * rightValue;
        }

        private void Update()
        {
            _nextPosition += 4;
            _opCode = ReadOpCode();
        }
    }
}
