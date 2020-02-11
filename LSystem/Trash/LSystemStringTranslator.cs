using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace LSystemVisual
{
    public class LSystemStringTranslator
    {
        private readonly HashSet<char> _variables;
        private readonly HashSet<char> _consts;
        private readonly IDictionary<char, string> _rules;
        private readonly string _start;
        public Dictionary<char, Action<Turtle>> Actions { get; } = new Dictionary<char, Action<Turtle>>();

        public LSystemStringTranslator(string variables, string consts, string start, params Rule[] rules)
        {
            _variables = new HashSet<char>(
                variables.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => Convert.ToChar(p)));
            _consts = new HashSet<char>(
                consts.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => Convert.ToChar(p)));
            _start = start;
            _rules = rules.ToDictionary(k => k.Var, v => v.Result);
        }

        public Geometry GenerateGeometry(int iteration)
        {
            string lPath = GenerateString(iteration);
            Point startPoint = new Point(0, 0);
            Turtle turtle = new Turtle(startPoint);
            Point newPoint = startPoint;
            PolyLineSegment pathSegment = new PolyLineSegment();
            foreach (var c in lPath)
            {
                if (Actions.TryGetValue(c, out var action))
                {
                    action(turtle);
                }
                if (newPoint != turtle.CurrentPosition.Point) pathSegment.Points.Add(newPoint = turtle.CurrentPosition.Point);
            }
            var figure = new PathFigure(startPoint, new[] { pathSegment }, false);
            return new PathGeometry(new[] { figure });
        }

        //const double STEP = 5;
        //private Point GetPoint(Point point, ref Direction dir, MoveDirection move)
        //{
        //    dir = GetDirection(dir, move);
        //    if (move != MoveDirection.Forward) return new Point(point.X, point.Y);

        //    switch (dir)
        //    {
        //        case Direction.Right:
        //            return new Point(point.X + STEP, point.Y);
        //        case Direction.Down:
        //            return new Point(point.X, point.Y + STEP);
        //        case Direction.Left:
        //            return new Point(point.X - STEP, point.Y);
        //        case Direction.Up:
        //            return new Point(point.X, point.Y - STEP);
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}

        //enum Direction
        //{
        //    Right = 0,
        //    Down = 1,
        //    Left = 2,
        //    Up = 3,
        //}

        //private Direction GetDirection(Direction dir, MoveDirection move)
        //{
        //    var result = (int)dir + (int)move;
        //    if (result < 0) result = 3;
        //    if (result > 3) result = 0;
        //    return (Direction)result;
        //}

        //enum MoveDirection
        //{
        //    Left = -1,
        //    Forward = 0,
        //    Right = 1,

        //}

        private string GenerateString(int iteration)
        {
            string result = _start;
            for (var i = 0; i < iteration; i++)
            {
                result = Replace(result);
            }
            return result;
        }

        private string Replace(string source)
        {
            StringBuilder result = new StringBuilder();
            foreach (var c in source)
            {
                if (_rules.TryGetValue(c, out string value))
                    result.Append(value);
                else
                    result.Append(c);
            }
            return result.ToString();
        }
    }
}