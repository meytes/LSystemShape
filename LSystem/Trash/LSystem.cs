using System.Linq;
using System.Windows;

namespace LSystemVisual
{
    public class LSystem : Freezable
    {
        public double StartAngle { get { return (double)GetValue(StartAngleProperty); } set { SetValue(StartAngleProperty, value); } }
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(LSystem), new PropertyMetadata(0.0));

        public Point StartPoint { get { return (Point)GetValue(StartPointProperty); } set { SetValue(StartPointProperty, value); } }
        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point), typeof(LSystem), new PropertyMetadata(new Point(0,0)));

        public int Interation { get { return (int)GetValue(InterationProperty); } set { SetValue(InterationProperty, value); } }
        public static readonly DependencyProperty InterationProperty =
            DependencyProperty.Register("Interation", typeof(int), typeof(LSystem), new PropertyMetadata(1));

        public string Axiom { get { return (string)GetValue(AxiomProperty); } set { SetValue(AxiomProperty, value); } }
        public static readonly DependencyProperty AxiomProperty =
            DependencyProperty.Register("Axiom", typeof(string), typeof(LSystem), new PropertyMetadata(string.Empty));

        public OperationCollection Operations { get; } = new OperationCollection();
        public FreezableCollection<LExpression> Expressions { get; } = new ExpressionCollection();

        public override string ToString()
        {
            ReadPreamble();
            var variables = string.Join(",", ((ExpressionCollection)Expressions).Values.Select(p => p.From.ToString()));
            var consts = string.Join(",", Operations.Values.Select(p=>p.Name));
            var seed = Axiom;
            var expression = string.Join(",", ((ExpressionCollection)Expressions).Values.Select(p => p.ToString()));
            return $"{variables};{consts};{seed};{expression}";
        }

        protected override Freezable CreateInstanceCore()
        {
            return new LSystem();
        }
    }
}