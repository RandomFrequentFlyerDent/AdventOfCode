using System;
using System.Drawing;

namespace SantaShip.Circuitry.Paths
{
    public class PathFactory
    {
        public IPath CreateCommand(string command, Point startPath)
        {
            var direction = command[0];
            var length = Int32.TryParse(command.Substring(1), out int parsed) ? parsed : 0;

            if (direction == 'U')
                return new UpPath(startPath, length);
            if (direction == 'D')
                return new DownPath(startPath, length);
            if (direction == 'L')
                return new LeftPath(startPath, length);
            if (direction == 'R')
                return new RightPath(startPath, length);

            return null;
        }
    }
}
