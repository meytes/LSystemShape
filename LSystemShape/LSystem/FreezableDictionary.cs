using System.Collections.Generic;
using System.Windows;

namespace Meytes.WPF.LSystemShape
{
    public abstract class FreezableDictionary<T> 
        : FreezableCollection<T>, IReadOnlyDictionary<char, T>
        where T : DependencyObject
    {
        private IReadOnlyDictionary<char, T> _internalDictionary;

        internal FreezableDictionary() : base()
            => UpdateDictionary();

        internal FreezableDictionary(int count) : base(count)
            => UpdateDictionary();

        internal FreezableDictionary(IEnumerable<T> source) : base(source)
            => UpdateDictionary();

        public T this[char key] => _internalDictionary[key];
        public IEnumerable<char> Keys => _internalDictionary.Keys;
        public IEnumerable<T> Values => _internalDictionary.Values;
        public bool ContainsKey(char key) 
            => _internalDictionary.ContainsKey(key);
        public bool TryGetValue(char key, out T value)
            => _internalDictionary.TryGetValue(key, out value);
        IEnumerator<KeyValuePair<char, T>> IEnumerable<KeyValuePair<char, T>>.GetEnumerator()
            => _internalDictionary.GetEnumerator();

        protected override void OnChanged()
        {
            base.OnChanged();
            UpdateDictionary();
        }

        private void UpdateDictionary()
        {
            base.WritePreamble();

            var result = new Dictionary<char, T>();
            foreach (var i in this) result.Add(GetKey(i), i);
            _internalDictionary = result;
        }

        protected abstract char GetKey(T value);
    }
}