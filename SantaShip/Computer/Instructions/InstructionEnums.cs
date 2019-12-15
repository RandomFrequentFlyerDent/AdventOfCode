namespace SantaShip.Computer.Instructions
{
    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        Stop = 99
    }
}
