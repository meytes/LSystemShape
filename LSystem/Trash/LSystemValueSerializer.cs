using System;
using System.Windows.Markup;

namespace LSystemVisual
{
    public sealed class LSystemValueSerializer : ValueSerializer
    {
        public override bool CanConvertFromString(string value, IValueSerializerContext context)
        {
            return true;
        }

        public override object ConvertFromString(string value, IValueSerializerContext context)
        {
            throw new NotImplementedException();
            //var converter = new LSystemTypeConverter();
            //LSystem lSystem = (LSystem)converter.ConvertFrom(value);
            //return lSystem;
        }

        public override bool CanConvertToString(object value, IValueSerializerContext context)
        {
            return true;
        }

        public override string ConvertToString(object value, IValueSerializerContext context)
        {
            if (value is LSystem lSystem) return lSystem.ToString();
            return "Error";
        }
    }
}