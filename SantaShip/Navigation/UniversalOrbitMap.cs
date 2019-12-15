using System.Collections.Generic;
using System.Linq;

namespace SantaShip.Navigation
{
    public class UniversalOrbitMap
    {
        private readonly List<OrbitalRoute> _routes;
        private readonly List<string> _map;

        public UniversalOrbitMap(List<string> map)
        {
            _routes = new List<OrbitalRoute>();
            _map = map;
        }

        public int GetTotalNumberDirectAndIndirectOrbits()
        {
            DetermineRoutes();
            return _routes.Sum(r => r.Route.Count);
        }

        private void DetermineRoutes()
        {
            var centerOfMass = _map.Where(m => m.StartsWith("COM)")).Single();
            var orbitSign = centerOfMass.IndexOf(')');
            var orbitter = centerOfMass.Substring(orbitSign + 1);

            var route = new OrbitalRoute();
            route.AddSpaceObject(orbitter);
            _routes.Add(route);
            _map.Remove(centerOfMass);
            UpdateRoute(route, orbitter);
        }

        private void UpdateRoute(OrbitalRoute route, string lastSpaceObject)
        {
            var orbitalInfo = _map.Where(m => m.StartsWith(lastSpaceObject)).ToList();

            if (orbitalInfo == null)
                return;

            foreach (var information in orbitalInfo)
            {
                var orbitSign = information.IndexOf(')');
                var orbitter = information.Substring(orbitSign + 1);

                var newRoute = new OrbitalRoute();
                newRoute.AddSpaceObjects(route.Route);
                newRoute.AddSpaceObject(orbitter);
                _routes.Add(newRoute);
                UpdateRoute(newRoute, orbitter);
            }
        }
    }
}
