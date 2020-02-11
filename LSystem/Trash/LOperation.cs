using System.Windows;

namespace LSystemVisual
{
    public sealed class LOperation : Freezable
    {
        public char Name { get { return (char)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(char), typeof(LOperation), new FrameworkPropertyMetadata('?'));

        public TurtleAction Action { get { return (TurtleAction)GetValue(ActionProperty); } set { SetValue(ActionProperty, value); } }
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(TurtleAction), typeof(LOperation), new FrameworkPropertyMetadata(TurtleAction.Nothing));

        public double Value { get { return (double)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(LOperation), new FrameworkPropertyMetadata(0.0));

        public override string ToString() => Name.ToString();

        protected override Freezable CreateInstanceCore() => new LOperation();
    }
}