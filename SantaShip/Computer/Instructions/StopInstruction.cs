namespace SantaShip.Computer.Instructions
{
    public class StopInstruction : IInstruction
    {
        public void Process(SoftwareProgram memory)
        {
            // No action required
        }

        public int MoveInstructionPointer()
        {
            return 0;
        }
    }
}
