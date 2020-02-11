using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    public sealed class LExpression : Freezable
    {
        public char From { get { return (char)GetValue(FromProperty); } set { SetValue(FromProperty, value); } }
        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(char), typeof(LExpression), 
                new PropertyMetadata('?'));

        public string To { get { return (string)GetValue(ToProperty); } set { SetValue(ToProperty, value); } }
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(string), typeof(LExpression), 
                new FrameworkPropertyMetadata(string.Empty));

        public override string ToString()
            => $"{nameof(LExpression)}: {From}->{To}";

        protected override Freezable CreateInstanceCore() => new LExpression();
    }
}