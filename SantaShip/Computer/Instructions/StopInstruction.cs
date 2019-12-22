namespace SantaShip.Computer.Instructions
{
    public class StopInstruction : IInstruction
    {
        public int NumberOfUsedMemorySlots { get { return 1; } }

        public int Process(ref int[] memory) { return 0; }
    }
}
