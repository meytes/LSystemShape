namespace LSystemVisual
{
    public class Rule
    {
        public Rule(char var, string result)
        {
            Var = var;
            Result = result;
        }

        public char Var { get; }
        public string Result { get; }
    }
}