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
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Stop = 99
    }
}
