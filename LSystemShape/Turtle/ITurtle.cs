namespace Meytes.WPF.LSystemShape
{
    internal interface ITurtle
    {
        void Turn(double angle);
        TurtlePosition Forward(double len = 5);
        void SaveAngle();
        TurtlePosition RestoreAngle();
        TurtlePosition CurrentPosition { get; }
    }
}
