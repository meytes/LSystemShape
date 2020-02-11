using System.Collections.Generic;
using System.Windows;

namespace LSystemVisual
{
    public class OperationCollection : 
        FreezableCollection<LOperation>
        //, IReadOnlyDictionary<char, LOperation>
    {
        private IReadOnlyDictionary<char, LOperation> _internalDictionary;
        public OperationCollection() : base() 
            => UpdateDictionary();

        public OperationCollection(int count) : base(count)
            => UpdateDictionary();

        public OperationCollection(IEnumerable<LOperation> source) : base(source)
            => UpdateDictionary();

        protected override void OnChanged()
        {
            base.OnChanged();
            UpdateDictionary();
        }

        private void UpdateDictionary()
        {
            var result = new Dictionary<char, LOperation>();
            foreach (var i in this) result.Add(i.Name, i);
            _internalDictionary = result;
        }

        #region IReadOnlyDictionary<char, LOperations> implimentation
        public LOperation this[char key]
            => _internalDictionary[key];
        public IEnumerable<char> Keys 
            => _internalDictionary.Keys;
        public IEnumerable<LOperation> Values
            => _internalDictionary.Values;
        public bool ContainsKey(char key) 
            => _internalDictionary.ContainsKey(key);
        public bool TryGetValue(char key, out LOperation value) 
            => _internalDictionary.TryGetValue(key, out value);
        //IEnumerator<KeyValuePair<char, LOperation>> IEnumerable<KeyValuePair<char, LOperation>>.GetEnumerator()
        //    => _internalDictionary.GetEnumerator();
        #endregion
    }
}