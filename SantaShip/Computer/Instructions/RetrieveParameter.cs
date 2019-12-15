namespace SantaShip.Computer.Instructions
{
    public class RetrieveParameter
    {
        private ParameterMode _mode;
        private int _position;

        public RetrieveParameter(ParameterMode mode, int position)
        {
            _mode = mode;
            _position = position;
        }

        public int GetValue(ref int[] memory)
        {
            if (_mode == ParameterMode.Immediate)
                return memory[_position];

            return memory[memory[_position]];
        }
    }
}
