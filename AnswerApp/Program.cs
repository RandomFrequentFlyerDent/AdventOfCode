namespace AnswerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var santaShip = new SantaShip();

            santaShip.Thrusters.GetHighestSignal(true);
            //santaShip.Thrusters.GetHighestSignal(false);
            //santaShip.NavSystem.GetTotalNumberDirectAndIndirectOrbits();
            //santaShip.DiagnosticProgram.Run(5);
            //santaShip.DiagnosticProgram.Run(1);
            //santaShip.VenusFuelContainer.GetNumberOfValidPasswords(372037, 905157, maxTwoAdjacent: true);
            //santaShip.VenusFuelContainer.GetNumberOfValidPasswords(372037, 905157, maxTwoAdjacent: false);
            //santaShip.Circuitry.GetDistanceFromCentralPortToClosestIntersectionAlongTheWire();
            //santaShip.Circuitry.GetDistanceFromCentralPortToClosestIntersectionByManhattan();
            //santaShip.GravityAssist.Activate(19690720);
            //santaShip.GravityAssist.Restore();
            //santaShip.ModuleInformation.DetermineTotalFuelRequirement();
            //santaShip.ModuleInformation.DetermineFuelRequirement();
        }
    }
}
