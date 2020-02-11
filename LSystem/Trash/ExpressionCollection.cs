using System.Collections.Generic;
using System.Windows;

namespace LSystemVisual
{
    public sealed class ExpressionCollection 
        : FreezableCollection<LExpression>
        //, IReadOnlyDictionary<char, LExpression>
    {
        private IReadOnlyDictionary<char, LExpression> _internalDictionary;
        public ExpressionCollection() : base()
            => UpdateDictionary();

        public ExpressionCollection(int count) : base(count)
            => UpdateDictionary();

        public ExpressionCollection(IEnumerable<LExpression> source) : base(source)
            => UpdateDictionary();

        protected override void OnChanged()
        {
            base.OnChanged();
            UpdateDictionary();
        }

        private void UpdateDictionary()
        {
            var result = new Dictionary<char, LExpression>();
            foreach (var i in this) result.Add(i.From, i);
            _internalDictionary = result;
        }

        #region IReadOnlyDictionary<char, LExpression> implimentation
        public LExpression this[char key]
            => _internalDictionary[key];
        public IEnumerable<char> Keys
            => _internalDictionary.Keys;
        public IEnumerable<LExpression> Values
            => _internalDictionary.Values;
        public bool ContainsKey(char key)
            => _internalDictionary.ContainsKey(key);
        public bool TryGetValue(char key, out LExpression value)
            => _internalDictionary.TryGetValue(key, out value);
        //IEnumerator<KeyValuePair<char, LExpression>> IEnumerable<KeyValuePair<char, LExpression>>.GetEnumerator()
        //    => _internalDictionary.GetEnumerator();
        #endregion
    }
}