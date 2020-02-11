namespace LSystemVisual
{

    namespace Visual
    {
        //public class LSystemGenerator
        //{
        //    private readonly Turtle _turtle = new Turtle(new Point(0, 0));

        //    private IDictionary<char, LOperand> _operands;

        //    private readonly Model.LSystem _lSystem;
        //    public LSystemGenerator(Model.LSystem lSystem)
        //    {
        //        _lSystem = lSystem;
        //        _operands = lSystem.Idioms.ToDictionary(p => p.Name);
        //    }

        //    public IEnumerable<Point> GetPoints(string start, int iterations)
        //    {
        //        return IEnumerablePoints(start, iterations);
        //    }

        //    private double DegreeToRadian(double angle)
        //    {
        //        return Math.PI * angle / 180.0;
        //    }

        //    private IEnumerable<Point> IEnumerablePoints(string expression, int depth)
        //    {
        //        foreach (var chr in expression)
        //        {
        //            if (_operands.TryGetValue(chr, out var operand))
        //            {
        //                //Рекурсия
        //                if (depth >  0 && operand is Model.LVariable variable)
        //                {
        //                    foreach (Point i in IEnumerablePoints(variable.Expression, depth - 1))
        //                    {
        //                        yield return i;
        //                    }
        //                }
        //                //Действие
        //                var act = operand.Act;
        //                if (act != null)
        //                {
        //                    if (act.Action == TurtleAction.Forward)
        //                    {
        //                        _turtle.Forward(act.Value);
        //                        yield return _turtle.CurrentPoint;
        //                    }
        //                    else if (act.Action == TurtleAction.Turn)
        //                    {
        //                        var value = act.Value;
        //                        _turtle.Turn(DegreeToRadian(value));
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    public static Geometry GetGeometry(Model.LSystem lSystem)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
