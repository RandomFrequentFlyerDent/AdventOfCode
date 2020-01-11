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

        public int GetValue(ref int[] memory)
        {
            if (_mode == ParameterMode.Immediate)
                return memory[_position];

            if (_mode == ParameterMode.Relative)
                return memory[memory[_relativeBase + _position]];

            return memory[memory[_position]];
        }
    }
}
