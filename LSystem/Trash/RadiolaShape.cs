using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LSystemVisual
{
    public class RadiolaShape : Shape
    {


        public int Mutex
        {
            get { return (int)GetValue(MutexProperty); }
            set { SetValue(MutexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mutex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MutexProperty =
            DependencyProperty.Register("Mutex", typeof(int), typeof(RadiolaShape), new FrameworkPropertyMetadata(2, FrameworkPropertyMetadataOptions.AffectsRender  ));



        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(RadiolaShape), new FrameworkPropertyMetadata(10, FrameworkPropertyMetadataOptions.AffectsRender));


        private Geometry GenerateGeometry(int mutex, int count)
        {
            PathGeometry pathGeometry = new PathGeometry();
            double radius = Math.Min(ActualWidth, ActualHeight ) / 2.0 - 10;
            Point center = new Point(ActualWidth / 2.0, ActualHeight / 2.0);
            
            double pointStep = Math.PI * 2.0 / count;
            //Point[] referencePoints = new Point[count];
            for (int i = 0; i < Count; i++)
            {
                double startX = center.X + Math.Cos(i * pointStep) * radius;
                double startY = center.Y + Math.Sin(i * pointStep) * radius;
                double endAngle = (i * mutex % count) * pointStep;
                Point startPoint = new Point(startX, startY);
                double endX = center.X + Math.Cos(endAngle) * radius;
                double endY = center.Y + Math.Sin(endAngle) * radius;
                Point endPoint = new Point(endX, endY);
                LineSegment lineSegment = new LineSegment(endPoint, true);
                PathFigure figure = new PathFigure() { StartPoint = startPoint, Segments = { lineSegment } };
                pathGeometry.Figures.Add(figure);
            }
            return pathGeometry;
        }
        protected override Geometry DefiningGeometry => GenerateGeometry(Mutex, Count);
    }
}
