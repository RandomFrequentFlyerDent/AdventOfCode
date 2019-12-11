namespace AnswerApp
{
    public class SantaShip
    {
        public GravityAssistProgram GravityAssist { get; }
        public ModuleInformation ModuleInformation { get; }

        public SantaShip()
        {
            GravityAssist = new GravityAssistProgram();
            ModuleInformation = new ModuleInformation();
        }
    }
}
