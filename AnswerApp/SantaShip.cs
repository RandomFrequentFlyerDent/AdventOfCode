namespace AnswerApp
{
    public class SantaShip
    {
        public GravityAssistProgram GravityAssist { get; }
        public ModuleInformation ModuleInformation { get; }
        public Circuitry Circuitry { get; }
        public VenusFuelContainer VenusFuelContainer { get; }
        public DiagnosticProgram DiagnosticProgram { get; }
        public NavSystem NavSystem { get; }

        public SantaShip()
        {
            GravityAssist = new GravityAssistProgram();
            ModuleInformation = new ModuleInformation();
            Circuitry = new Circuitry();
            VenusFuelContainer = new VenusFuelContainer();
            DiagnosticProgram = new DiagnosticProgram();
            NavSystem = new NavSystem();
        }
    }
}
