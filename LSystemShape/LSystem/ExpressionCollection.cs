using System.Collections.Generic;

namespace Meytes.WPF.LSystemShape
{
    public sealed class ExpressionCollection : FreezableDictionary<LExpression>
    {
        public ExpressionCollection() : base() { }

        public ExpressionCollection(int count) : base(count) { }

        public ExpressionCollection(IEnumerable<LExpression> source) : base(source) { }

        protected override char GetKey(LExpression value) => value.From;
    }
}