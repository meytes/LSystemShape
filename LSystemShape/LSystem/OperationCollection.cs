using System.Collections.Generic;

namespace Meytes.WPF.LSystemShape
{
    public sealed class OperationCollection :
        FreezableDictionary<LOperation>
    {
        public OperationCollection() : base() { }

        public OperationCollection(int count) : base(count) { }

        public OperationCollection(IEnumerable<LOperation> source) : base(source) { }

        protected override char GetKey(LOperation value) => value.Name;
    }
}