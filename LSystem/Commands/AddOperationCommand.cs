using Meytes.WPF.LSystemShape;
using System.Windows.Input;

namespace LSystemVisual.Commands
{

    public class AppendOperationCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            if (parameter is Meytes.WPF.LSystemShape.LSystem lSystem)
            {
                return !lSystem.Operations.ContainsKey('?');
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Meytes.WPF.LSystemShape.LSystem lSystem)
            {
                if (!lSystem.Operations.ContainsKey('?')) lSystem.Operations.Add(new LOperation());
            }
        }
    }
}
