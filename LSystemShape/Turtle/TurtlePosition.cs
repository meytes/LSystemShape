using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    internal struct TurtlePosition
    {
        internal TurtlePosition(Point position, double angle)
        {
            Point = position;
            Angle = angle;
        }
        public Point Point { get; }
        public double Angle { get; }
    }
}
