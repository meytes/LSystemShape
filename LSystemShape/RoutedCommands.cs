using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meytes.WPF.LSystemShape
{
    public static class RoutedCommands
    {


        public static ICommand RemoveOperation = new RoutedCommand(nameof(RemoveOperation), typeof(RoutedCommands));
        public static ICommand RemoveExpression = new RoutedCommand(nameof(RemoveExpression), typeof(RoutedCommands));
    }

}
