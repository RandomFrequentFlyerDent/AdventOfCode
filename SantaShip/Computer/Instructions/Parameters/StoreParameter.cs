namespace SantaShip.Computer.Instructions.Parameters
{
    public class StoreParameter
    {
        private readonly ParameterMode _mode;
        public int _relativeBase { get; private set; }
        public  int Position { get; private set; }

        public StoreParameter(ParameterMode mode, int position, int relativeBase)
        {
            _mode = mode;
            _relativeBase = relativeBase;
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

            if (_mode == ParameterMode.Relative)
                memory[memory[_relativeBase + Position]] = (int)value;
        }
    }
}
