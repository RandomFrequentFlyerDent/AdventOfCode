using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SantaShip;
using System.Linq;

namespace AnswerApp
{
    public class ModuleInformation
    {
        private List<ShipModule> _modules;

        public ModuleInformation()
        {
            _modules = new List<ShipModule>();
        }

        /// <summary>
        /// Day One Answer One
        /// </summary>
        public void DetermineFuelRequirement()
        {
            GatherModules();
            var req = _modules.Sum(m => m.CalculateFuelRequirement());
            Console.WriteLine($"Fuel requirement for the modules is {req}");
        }

        /// <summary>
        /// Day One Answer One
        /// </summary>
        public void DetermineTotalFuelRequirement()
        {
            GatherModules();
            var req = _modules.Sum(m => m.CalculateTotalFuelRequirement());
            Console.WriteLine($"Total fuel requirement for the ship is {req}");
        }

        private void GatherModules()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AnswerApp.input.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (Int64.TryParse(line, out long result))
                        _modules.Add(new ShipModule(result));
                }
            }
        }
    }
}
