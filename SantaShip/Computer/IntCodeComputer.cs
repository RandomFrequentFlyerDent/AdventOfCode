using SantaShip.Computer.Instructions;

namespace SantaShip
{
    public class IntCodeComputer
    {
        public int[] Memory { get { return _memory; } }
        private int[] _memory;
        public static int InstructionPointer { get; set; }
        public int Input { get; set; }
        public int Output { get; private set; }

        public IntCodeComputer(int[] memory)
        {
            _memory = memory;
            InstructionPointer = 0;
        }

        public void SetNoun(int noun)
        {
            _memory[1] = noun;
        }

        public void SetVerb(int verb)
        {
            _memory[2] = verb;
        }

        public void Process()
        {
            var instructionFactory = new InstructionFactory();
            var lengthOfMemory = _memory.Length;
            var reading = true;

            do
            {
                var opCode = _memory[InstructionPointer];
                IInstruction instruction = instructionFactory.CreateInstruction(opCode, Input);
                if (instruction != null)
                {
                    if (instruction is StopInstruction)
                    {
                        reading = false;
                    }
                     else if (instruction is OutputInstruction)
                    {
                        Output = ((OutputInstruction)instruction).GetOutput(ref _memory);
                    }
                    else
                    {
                        instruction.Process(ref _memory);
                    }
                }
                else
                {
                    reading = false;
                }

            } while (reading && InstructionPointer < lengthOfMemory);
        }

        public int RetrieveValueFromMemory(int address)
        {
            return _memory[address];
        }
    }
}
