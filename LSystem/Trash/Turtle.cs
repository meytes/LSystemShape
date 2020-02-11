using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace LSystemVisual
{
    public interface ITurtle
    {
        void Turn(double angle);
        Point Forward(double len = 5);
        void SaveAngle();
        void RestoreAngle();
        List<Point> Path { get; }
        Point StartPoint { set; get; }
    }

    public struct TurtlePosition
    {
        public TurtlePosition(bool isBreak) : this(new Point(0,0), 0)
        {
            IsBreak = isBreak;
        }
        public TurtlePosition(Point position, double angle)
        {
            Point = position;
            Angle = angle;
            IsBreak = false;
        }

        public Point Point { get; }
        public double Angle { get; }

        public bool IsBreak { get; }
    }

    public class Turtle 
    {
        private Stack<TurtlePosition> _savedPositions = new Stack<TurtlePosition>();

        private TurtlePosition _curPos;
        public TurtlePosition CurrentPosition => _curPos;
        
        public Point StartPoint { get; }
        public Turtle(Point startPoint, double currentAngle = 0.0)
        {
            StartPoint = startPoint;
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

        public void RestoreAngle()
        {
            if (_savedPositions.Count > 0) _curPos = _savedPositions.Pop();
        }
    }
}
