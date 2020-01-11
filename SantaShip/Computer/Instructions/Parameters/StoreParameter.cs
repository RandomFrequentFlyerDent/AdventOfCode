namespace SantaShip.Computer.Instructions.Paramters
{
    public class StoreParameter
    {
        private ParameterMode _mode;
        public  int Position { get; private set; }
        public int RelativeBase { get; private set; }

        public StoreParameter(ParameterMode mode, int position, int relativeBase)
        {
            _mode = mode;
            Position = position;
            RelativeBase = relativeBase;
        }

        public void StoreValue(ref int[] memory, int? value)
        {
            if (value == null)
                return;

            if (_mode == ParameterMode.Immediate)
                memory[Position] = (int)value;

            if (_mode == ParameterMode.Position)
                memory[memory[Position]] = (int)value;

            if (_mode == ParameterMode.Relative)
                memory[memory[RelativeBase + Position]] = (int)value;
        }
    }
}
