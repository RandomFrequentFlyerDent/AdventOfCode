using System;

namespace SantaShip
{
    public class ShipModule
    {
        private long _mass;

        public ShipModule(long mass)
        {
            _mass = mass;
        }

        public long CalculateFuelRequirement()
        {
            return CalculateFuelRequirement(_mass);
        }

        private long CalculateFuelRequirement(long mass)
        {
            var requirement = Convert.ToInt64(Math.Floor(mass / 3.0) - 2);
            return requirement < 0 ? 0 : requirement;
        }

        public long CalculateTotalFuelRequirement()
        {
            return CalculateTotalFuelRequirement(_mass);
        }

        private long CalculateTotalFuelRequirement(long mass)
        {
            var requirement = CalculateFuelRequirement(mass);
            if (requirement == 0)
                return requirement;

            return requirement + CalculateTotalFuelRequirement(requirement);
        }
    }
}
