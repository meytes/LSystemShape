using System;
using System.Collections.Generic;
using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    internal class Turtle : ITurtle
    {
        private readonly Stack<TurtlePosition> _savedPositions = new Stack<TurtlePosition>();

        private TurtlePosition _curPos;
        public TurtlePosition CurrentPosition => _curPos;
        internal Turtle(Point startPoint, double currentAngle = 0.0)
        {
            _curPos = new TurtlePosition(startPoint, currentAngle);
        }

        public void Turn(double angle)
        {
            _curPos = new TurtlePosition(_curPos.Point, _curPos.Angle + angle);
        }

        public TurtlePosition Forward(double len = 5.0)
        {
            var angleRad = Math.PI * (_curPos.Angle / 180.0);
            double x = _curPos.Point.X + Math.Cos(angleRad) * len;
            double y = _curPos.Point.Y + Math.Sin(angleRad) * len;
            _curPos = new TurtlePosition(new Point(x, y), _curPos.Angle);
            return _curPos;
        }

        public void SaveAngle()
        {
            _savedPositions.Push(_curPos);
        }

        public TurtlePosition RestoreAngle()
        {
            if (_savedPositions.Count > 0)
                return _curPos = _savedPositions.Pop();
            throw new IndexOutOfRangeException("Position stack is empty");
        }

    }
}
