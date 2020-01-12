using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SantaShip.Computer
{
    public class Camera
    {
        private CameraDirection _direction;
        public Point Position { get; private set; }

        public Camera(CameraDirection direction, Point position)
        {
            _direction = direction;
            Position = position;
        }

        public PanelColor Scan(Dictionary<Point, List<PanelColor>> hull)
        {
            var scannedColors = hull.GetValueOrDefault(Position);
            if (scannedColors != null)
                return scannedColors.Last();

            return PanelColor.Black;
        }

        public void MoveCamera(CameraTurn turn)
        {
            _direction = _direction.Turn(turn);
            Position = _direction.RePositionCamera(Position);
        }
    }

    public enum PanelColor { Black, White }
    public enum CameraDirection { Up, Right, Down, Left }
    public enum CameraTurn { Left, Right }
    static class CameraExtensions
    {
        public static CameraDirection Turn(this CameraDirection direction, CameraTurn turn)
        {
            if (direction == CameraDirection.Up && turn == CameraTurn.Left)
                return CameraDirection.Left;

            if (direction == CameraDirection.Up && turn == CameraTurn.Right)
                return CameraDirection.Right;

            if (direction == CameraDirection.Right && turn == CameraTurn.Left)
                return CameraDirection.Up;

            if (direction == CameraDirection.Right && turn == CameraTurn.Right)
                return CameraDirection.Down;

            if (direction == CameraDirection.Down && turn == CameraTurn.Left)
                return CameraDirection.Right;

            if (direction == CameraDirection.Down && turn == CameraTurn.Right)
                return CameraDirection.Left;

            if (direction == CameraDirection.Left && turn == CameraTurn.Left)
                return CameraDirection.Down;

            if (direction == CameraDirection.Left && turn == CameraTurn.Right)
                return CameraDirection.Up;

            throw new System.Exception($"Unable to turn {turn} from {direction}");
        }

        public static Point RePositionCamera(this CameraDirection direction, Point position)
        {
            if (direction == CameraDirection.Up)
                return new Point(position.X, position.Y + 1);

            if (direction == CameraDirection.Right)
                return new Point(position.X + 1, position.Y);

            if (direction == CameraDirection.Down)
                return new Point(position.X, position.Y - 1);

            if (direction == CameraDirection.Left)
                return new Point(position.X - 1, position.Y);

            throw new System.Exception($"Unable to reposition {direction} from {position}");
        }
    }
}
