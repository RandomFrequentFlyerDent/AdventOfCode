namespace SantaShip.Computer.Instructions
{
    public interface IInstruction
    {
        void Process(SoftwareProgram memory);
        int MoveInstructionPointer();
    }
}
