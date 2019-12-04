using System;

namespace DayOne
{
    public class FuelCalculator
    {
        public static long CalculateFuelRequirement(long mass)
        {
            var requirement = Convert.ToInt64(Math.Floor(mass / 3.0) - 2);
            return requirement < 0 ? 0 : requirement;
        }

        public static long CalculateAllTheFuelRequirements(long mass)
        {
            var requirement = CalculateFuelRequirement(mass);
            if (requirement == 0)
                return requirement;

            return requirement + CalculateAllTheFuelRequirements(requirement);
        }
    }
}
