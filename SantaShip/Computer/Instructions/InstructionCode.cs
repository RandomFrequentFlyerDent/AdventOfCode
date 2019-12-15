namespace SantaShip.Computer.Instructions
{
    public class InstructionCode
    {
        public OpCode OpCode { get; private set; }
        public ParameterMode FirstParameterMode { get; private set; }
        public ParameterMode SecondParameterMode { get; private set; }
        public ParameterMode ThirdParameterMode { get; private set; }

        public InstructionCode(string code)
        {
            SetOpCode(code);
            SetParameterModes(code);
        }

        private void SetOpCode(string code)
        {
            if (code.Length == 1 || code.Length == 2)
            {
                OpCode = (OpCode)(int.Parse(code));
            }
            else
            {
                var opCode = int.Parse(code
                    .PadLeft(5, '0')
                    .Substring(3));

                OpCode = (OpCode)opCode;
            }
        }

        private void SetParameterModes(string code)
        {
            if (code.Length == 1 || code.Length == 2)
            {
                FirstParameterMode = ParameterMode.Position;
                SecondParameterMode = ParameterMode.Position;
                ThirdParameterMode = ParameterMode.Position;
            }
            else
            {
                code = code.PadLeft(5, '0');
                FirstParameterMode = (ParameterMode)(int.Parse(code[2].ToString()));
                SecondParameterMode = (ParameterMode)(int.Parse(code[1].ToString()));
                ThirdParameterMode = (ParameterMode)(int.Parse(code[0].ToString()));
            }
        }
    }
}
