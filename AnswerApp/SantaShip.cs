namespace AnswerApp
{
    public class SantaShip
    {
        public GravityAssistProgram GravityAssist { get { return new GravityAssistProgram(); } }
        public ModuleInformation ModuleInformation { get { return new ModuleInformation(); } }
        public Circuitry Circuitry { get { return new Circuitry(); } }
        public VenusFuelContainer VenusFuelContainer { get { return new VenusFuelContainer(); } }
        public DiagnosticProgram DiagnosticProgram { get { return new DiagnosticProgram(); } }
        public NavSystem NavSystem { get { return new NavSystem(); } }
        public Thrusters Thrusters { get { return new Thrusters(); } }
    }
}
