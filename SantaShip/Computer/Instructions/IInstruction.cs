namespace SantaShip.Computer.Instructions
{
    public interface IInstruction
    {
        int NumberOfUsedMemorySlots { get; }
        void Process(ref int[] memory);
    }
}
