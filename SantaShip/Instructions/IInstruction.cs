namespace SantaShip
{
    public interface IInstruction
    {
        int NumberOfUsedMemorySlots { get; }
        void Process(ref int[] memory);
    }
}
