using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    public sealed class LOperation : Freezable
    {
        public char Name { get { return (char)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(char), typeof(LOperation), new FrameworkPropertyMetadata('?', LSystem.AffectedProperty));

        public TurtleAction Action { get { return (TurtleAction)GetValue(ActionProperty); } set { SetValue(ActionProperty, value); } }
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(TurtleAction), typeof(LOperation), new FrameworkPropertyMetadata(TurtleAction.Nothing, LSystem.AffectedProperty));

        public double Value { get { return (double)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(LOperation), new FrameworkPropertyMetadata(0.0, LSystem.AffectedProperty));

        public override string ToString() 
            => $"{nameof(LExpression)}: {Name} - {Action}"
            + ((Value == 0.0) ? string.Empty : $" by {Value}"); 

        protected override Freezable CreateInstanceCore() => new LOperation();
    }
}