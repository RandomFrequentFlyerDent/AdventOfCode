using System;
using System.Collections.Generic;

namespace SantaShip.Navigation
{
    public class OrbitalRoute
    {
        public List<string> Route { get; }

        public OrbitalRoute()
        {
            Route = new List<string>();
        }

        public void AddSpaceObject(string spaceObject)
        {
            Route.Add(spaceObject);
        }

        internal void AddSpaceObjects(List<string> route)
        {
            Route.AddRange(route);
        }
    }
}
