namespace SantaShip.Propulsion
{
    public class Amplifiers
    {
        private int[] _memory;
        private int[] _phaseSequence;

        public Amplifiers(int[] memory, int[] phaseSequence)
        {
            _memory = memory;
            _phaseSequence = phaseSequence;
        }

        public int GetThrusterSignal()
        {
            var input = 0;
            var output = int.MinValue;
            foreach (var phase in _phaseSequence)
            {
                var computer = new IntCodeComputer(_memory)
                {
                    Input = phase
                };
                computer.Input = input;
                computer.Process();
                input = computer.Output;
                output = computer.Output;
            }
            return output;
        }
    }
}
