namespace SantaShip.Computer.Instructions
{
    public class StopInstruction : IInstruction
    {
        public int NumberOfUsedMemorySlots { get { return 1; } }

        public void Process(ref int[] memory) { }
    }
}
