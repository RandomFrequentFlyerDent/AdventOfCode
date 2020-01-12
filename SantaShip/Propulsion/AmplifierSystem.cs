using SantaShip.Computer;

namespace SantaShip.Propulsion
{
    public class AmplifierSystem
    {
        private int[] _memory;
        private int[] _phaseSequence;

        private IntCodeComputer _amplifierA;
        private IntCodeComputer _amplifierB;
        private IntCodeComputer _amplifierC;
        private IntCodeComputer _amplifierD;
        private IntCodeComputer _amplifierE;

        public AmplifierSystem(int[] memory, int[] phaseSequence)
        {
            _memory = memory;
            _phaseSequence = phaseSequence;

            _amplifierA = new IntCodeComputer(_memory.Clone() as int[]);
            _amplifierB = new IntCodeComputer(_memory.Clone() as int[]);
            _amplifierC = new IntCodeComputer(_memory.Clone() as int[]);
            _amplifierD = new IntCodeComputer(_memory.Clone() as int[]);
            _amplifierE = new IntCodeComputer(_memory.Clone() as int[]);

            _amplifierE.OutputReceiver = _amplifierA;
            _amplifierD.OutputReceiver = _amplifierE;
            _amplifierC.OutputReceiver = _amplifierD;
            _amplifierB.OutputReceiver = _amplifierC;
            _amplifierA.OutputReceiver = _amplifierB;
        }

        public long GetThrusterSignal()
        {
            _amplifierA.Input = _phaseSequence[0];
            _amplifierA.Input = 0;
            _amplifierB.Input = _phaseSequence[1];
            _amplifierC.Input = _phaseSequence[2];
            _amplifierD.Input = _phaseSequence[3];
            _amplifierE.Input = _phaseSequence[4];

            do
            {
                _amplifierA.Process();
                _amplifierB.Process();
                _amplifierC.Process();
                _amplifierD.Process();
                _amplifierE.Process();

            } while (!_amplifierE.HasStopped);

            return _amplifierE.Output;
        }
    }
}
