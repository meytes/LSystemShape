using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LSystemVisual
{
    [DefaultProperty("System")]
    [ContentProperty("System")]
    public class LSystemShape : Shape
    {
        public LSystem System
        {
            get { return (LSystem)GetValue(SystemProperty); }
            set { SetValue(SystemProperty, value); }
        }

        public static readonly DependencyProperty SystemProperty =
            DependencyProperty.Register("System", typeof(LSystem), typeof(LSystemShape), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var shape = (LSystemShape)d;
            //if (e.NewValue is LSystem lsystem)
            //{
            //    Debug.Print(lsystem.ToString());
            //    shape._internalGeometry = 
            // }
        }

        protected override Geometry DefiningGeometry => GenerateGeometry(System);

        private Geometry GenerateGeometry(LSystem system)
        {

            Turtle turtle = new Turtle(system.StartPoint, system.StartAngle);
            var pathGeometry = new PathGeometry();
            Draw(pathGeometry, system.Axiom, turtle, system, 0);
            pathGeometry.Freeze();
            return pathGeometry;
        }

        //private Geometry GetGeometryFromPoints(Turtle turtle)
        //{
            
        //    PolyLineSegment pathSegment = new PolyLineSegment();
        //    foreach (var position in turtle.Path)
        //    {
        //        pathSegment.Points.Add(position.Point);
        //    }
        //    return new PathGeometry()
        //    {
        //        Figures =
        //        {
        //            new PathFigure()
        //            {
        //                StartPoint = turtle.StartPoint,
        //                Segments =
        //                {
        //                    pathSegment
        //                },
        //                IsClosed = false
        //            }
        //        }
        //    };

        //}

        private void Draw(PathGeometry geometry, string expression, Turtle turtle, LSystem system, int currentLevel)
        {
            if (geometry.Figures.Count == 0)
            {
                geometry.Figures.Add(new PathFigure() { Segments = { new PolyLineSegment() }, StartPoint = turtle.CurrentPosition.Point });
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
                    switch (operation.Action)
                    {
                        case TurtleAction.Forward:
                            var position = turtle.Forward(operation.Value);
                            ((PolyLineSegment)geometry.Figures[geometry.Figures.Count - 1].Segments[0]).Points.Add(position.Point);
                            break;
                        case TurtleAction.Turn:
                            turtle.Turn(operation.Value);
                            break;
                        case TurtleAction.Save:
                            turtle.SaveAngle();
                            break;
                        case TurtleAction.Restore:
                            turtle.RestoreAngle();
                            geometry.Figures.Add(new PathFigure() { Segments = { new PolyLineSegment() }, StartPoint = turtle.CurrentPosition.Point });
                            break;
                    }
                }
            }
        }


        // _internalGeometry ?? Geometry.Empty;

        //if (System == null) return null;
        //var lSystem = new LSystem("", "", "", new Rule[0]);
        //lSystem.G
        //return LSystem
    }
}