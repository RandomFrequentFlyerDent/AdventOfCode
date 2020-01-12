using System;

namespace SantaShip.Computer.Instructions.Parameters
{
    public class RetrieveParameter
    {
        private readonly ParameterMode _mode;
        private readonly int _position;
        private readonly int _relativeBase;

        public RetrieveParameter(ParameterMode mode, int position, int relativeBase)
        {
            _mode = mode;
            _position = position;
            _relativeBase = relativeBase;
        }

        public long GetValue(ref SoftwareProgram memory)
        {
            if (_mode == ParameterMode.Immediate)
                return memory[_position];

            if (_mode == ParameterMode.Position)
                return memory[Convert.ToInt32(memory[_position])];

            var index = Convert.ToInt32(memory[_position]);
            return memory[_relativeBase + index];
        }
    }
}
