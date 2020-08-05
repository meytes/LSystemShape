using Meytes.WPF.LSystemShape;

namespace LSystemVisual.Commands
{
    public class AppendExpressionCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            if (parameter is Meytes.WPF.LSystemShape.LSystem lSystem)
            {
                return !lSystem.Expressions.ContainsKey('?');
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Meytes.WPF.LSystemShape.LSystem lSystem)
            {
                if (!lSystem.Expressions.ContainsKey('?')) lSystem.Expressions.Add(new LExpression());
            }
        }
    }
}
