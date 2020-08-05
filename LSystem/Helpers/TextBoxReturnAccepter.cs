using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LSystemVisual.Helpers
{
    public class TextBoxReturnAccepter
    {


        public static bool GetEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledProperty);
        }

        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(TextBoxReturnAccepter), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue && d is TextBox oldBox)
            {
                oldBox.PreviewKeyDown -= NewBox_PreviewKeyDown;

            }
            if ((bool)e.NewValue && d is TextBox newBox)
            {
                newBox.PreviewKeyDown += NewBox_PreviewKeyDown;
            }
        }

        private static void NewBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (sender is TextBox box && e.Key == System.Windows.Input.Key.Enter)
            {
                var exp = BindingOperations.GetBindingExpression(box, TextBox.TextProperty);
                exp.UpdateSource();
            }
        }
    }
}
