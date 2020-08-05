using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Meytes.WPF.LSystemShape
{
    [DefaultProperty("System")]
    [ContentProperty("System")]
    public class LSystemShape : Shape
    {
        public LSystemShape()
        {
            Focusable = true;
        }
        static LSystemShape()
        {
            CommandManager.RegisterClassCommandBinding(typeof(LSystemShape), new CommandBinding(RoutedCommands.RemoveExpression, OnRemoveExpression, CanRemoveExpression));
        }

        private static void CanRemoveExpression(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private static void OnRemoveExpression(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is LSystemShape shape && e.Parameter is LExpression exp)
            {
                shape.System.Expressions.Remove(exp);
            }
        }

        public LSystem System
        {
            get { return (LSystem)GetValue(SystemProperty); }
            set { SetValue(SystemProperty, value); }
        }

        public static readonly DependencyProperty SystemProperty =
            DependencyProperty.Register("System", typeof(LSystem), typeof(LSystemShape), new FrameworkPropertyMetadata(null, LSystem.AffectedProperty));
        protected override Geometry DefiningGeometry => GenerateGeometry(System);

        /// <summary> Generate geometry from LSystem object </summary>
        /// <param name="system">LSystem object</param>
        /// <returns>Result geometry</returns>
        private Geometry GenerateGeometry(LSystem system)
        {
            if (system == null) return Geometry.Empty;
            ITurtle turtle = new Turtle(system.StartPoint, system.StartAngle);
            PathGeometry pathGeometry = new PathGeometry();
            Draw(pathGeometry, system.Axiom, turtle, system, 0);
            pathGeometry.Freeze();
            return pathGeometry;
        }

        private void Draw(PathGeometry geometry, string expression, ITurtle turtle, LSystem system, int currentLevel)
        {
            if (geometry.Figures.Count == 0)
            {
                geometry.Figures.Add(new PathFigure() { Segments = { new PolyLineSegment() }, StartPoint = turtle.CurrentPosition.Point, IsClosed = System.IsClosed, IsFilled = System.IsFilled });
            }
            for (var i = 0; i < expression.Length; i++)
            {
                var chr = expression[i];
                if (currentLevel < system.Interation
                    && ((ExpressionCollection)system.Expressions).TryGetValue(chr, out LExpression childExpression))
                {
                    Draw(geometry, childExpression.To, turtle, system, currentLevel + 1);
                }
                else if (system.Operations.TryGetValue(chr, out LOperation operation))
                {
                    TurtlePosition position;
                    switch (operation.Action)
                    {
                        case TurtleAction.Forward:
                            position = turtle.Forward(operation.Value);
                            ((PolyLineSegment)geometry.Figures[geometry.Figures.Count - 1].Segments[0]).Points.Add(position.Point);
                            break;
                        case TurtleAction.Turn:
                            turtle.Turn(operation.Value);
                            break;
                        case TurtleAction.Save:
                            turtle.SaveAngle();
                            break;
                        case TurtleAction.Restore:
                            position = turtle.RestoreAngle();
                            geometry.Figures.Add(new PathFigure() { Segments = { new PolyLineSegment() }, StartPoint = position.Point, IsClosed = System.IsClosed, IsFilled = System.IsFilled });
                            break;
                    }
                }
            }
        }
    }
}