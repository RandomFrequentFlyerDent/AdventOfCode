namespace SantaShip.Computer.Instructions
{
    public interface IInstruction
    {
        void Process(ref int[] memory);
    }
}
