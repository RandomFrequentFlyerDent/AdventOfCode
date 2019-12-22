namespace SantaShip.Computer.Instructions
{
    public interface IInstruction
    {
        int Process(ref int[] memory);
    }
}
