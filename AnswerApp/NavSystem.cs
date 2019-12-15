using SantaShip.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnswerApp
{
    public class NavSystem
    {
        private readonly UniversalOrbitMap _universalOrbitMap;

        public NavSystem()
        {
            _universalOrbitMap = new UniversalOrbitMap(DownloadMap());
        }

        public void GetTotalNumberDirectAndIndirectOrbits()
        {
            var total = _universalOrbitMap.GetTotalNumberDirectAndIndirectOrbits();
            Console.WriteLine($"Total number of direct and indirect orbits is {total}");
        }

        private List<string> DownloadMap()
        {
            var map = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AnswerApp.mapInput.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    map.Add(line);
                }
            }
            return map;
        }
    }
}
