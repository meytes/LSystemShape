using System.Windows;


namespace LSystemVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ////var lSystem = new LSystem("A", new Rule('A', "-BF+AFA+FB-"), new Rule('B', "+AF-BFB-FA+"));
            //var lSystem = new LSystem("A,B", "+,-", "A", new Rule('A', "+B-A-B+"), new Rule('B', "-A+B+A-"));
            //const double angle = Math.PI / 3.0;
            //lSystem.Actions.Add('+', t => t.Turn(-angle));
            //lSystem.Actions.Add('-', t => t.Turn(angle));
            //lSystem.Actions.Add('A', t => t.Forward());
            //lSystem.Actions.Add('B', t => t.Forward());

            //var result = lSystem.GenerateGeometry(8);


            //Part_PATH.Data = result;
        }
    }
}
