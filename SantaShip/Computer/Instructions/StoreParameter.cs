namespace SantaShip.Computer.Instructions
{
    public class StoreParameter
    {
        private ParameterMode _mode;
        public  int Position { get; private set; }

        public StoreParameter(ParameterMode mode, int position)
        {
            _mode = mode;
            Position = position;
        }

        public void StoreValue(ref int[] memory, int? value)
        {
            if (value == null)
                return;

            if (_mode == ParameterMode.Immediate)
                memory[Position] = (int)value;

            if (_mode == ParameterMode.Position)
                memory[memory[Position]] = (int)value;
        }
    }
}
