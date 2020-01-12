using System.Collections.Generic;
using System.Drawing;

namespace SantaShip.Computer
{
    public class PaintingRobot
    {
        private IntCodeComputer _brain;
        private Camera _camera;
        public Dictionary<Point, List<PanelColor>> Hull { get; private set; }

        public PaintingRobot(long[] paintingInstructions)
        {
            _brain = new IntCodeComputer(paintingInstructions, outputReceiverIsSelf: true);
            _camera = new Camera(CameraDirection.Up, new Point(0, 0));
            Hull = new Dictionary<Point, List<PanelColor>>();
        }

        public void Paint()
        {
            do
            {
                PanelColor currentColor = _camera.Scan(Hull);
                _brain.Input = (int)currentColor;
                _brain.Process();

                PanelColor colorToPaint = (PanelColor)_brain.Output;
                if (Hull.TryGetValue(_camera.Position, out List<PanelColor> colors))
                {
                    colors.Add(colorToPaint);
                }
                else
                {
                    Hull.Add(_camera.Position, new List<PanelColor> { colorToPaint });
                }

                _brain.Process();

                var turn = _brain.Output;
                _camera.MoveCamera((CameraTurn)turn);

            } while (!_brain.HasStopped);
        }
    }
}
