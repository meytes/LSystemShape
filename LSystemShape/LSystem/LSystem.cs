using System;
using System.Linq;
using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    public class LSystem : Freezable
    {
        internal const FrameworkPropertyMetadataOptions AffectedProperty
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange;

        public double StartAngle { get { return (double)GetValue(StartAngleProperty); } set { SetValue(StartAngleProperty, value); } }
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register(nameof(StartAngle), typeof(double), typeof(LSystem), new PropertyMetadata(0.0));

        public Point StartPoint { get { return (Point)GetValue(StartPointProperty); } set { SetValue(StartPointProperty, value); } }
        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register(nameof(StartPoint), typeof(Point), typeof(LSystem), new PropertyMetadata(new Point(0,0)));

        public int Interation { get { return (int)GetValue(InterationProperty); } set { SetValue(InterationProperty, value); } }
        public static readonly DependencyProperty InterationProperty =
            DependencyProperty.Register(nameof(Interation), typeof(int), typeof(LSystem), new PropertyMetadata(1));

        public string Axiom { get { return (string)GetValue(AxiomProperty); } set { SetValue(AxiomProperty, value); } }
        public static readonly DependencyProperty AxiomProperty =
            DependencyProperty.Register(nameof(Axiom), typeof(string), typeof(LSystem), new PropertyMetadata(string.Empty));

        public bool IsClosed { get { return (bool)GetValue(IsClosedProperty); } set { SetValue(IsClosedProperty, value); } }
        public static readonly DependencyProperty IsClosedProperty =
            DependencyProperty.Register(nameof(IsClosed), typeof(bool), typeof(LSystem), new PropertyMetadata(false));
        public bool IsFilled { get { return (bool)GetValue(IsFilledProperty); } set { SetValue(IsFilledProperty, value); } }
        public static readonly DependencyProperty IsFilledProperty =
            DependencyProperty.Register(nameof(IsFilled), typeof(bool), typeof(LSystem), new PropertyMetadata(false));

        public OperationCollection Operations { get; }
        
        public ExpressionCollection Expressions { get; }

        protected override Freezable CreateInstanceCore() => new LSystem();

        public LSystem()
        {
            Operations = new OperationCollection();
            Operations.Changed += Change;
            Expressions = new ExpressionCollection();
            Expressions.Changed += Change;
        }

        private void Change(object sender, EventArgs e) => WritePostscript();
    }
}