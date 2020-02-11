using System.Diagnostics;

using System.Windows;

namespace LSystemVisual
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
            mainWindow.Activate();
            
            
        }
    }
}
