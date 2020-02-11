using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace LSystemVisual
{
    //public sealed class LSystemTypeConverter : TypeConverter
    //{
    //    private LSystem ConvertFromString(CultureInfo culture, string lSystem)
    //    {
    //        string[] lSystemBlocks = lSystem.Split(';');

    //        if (lSystemBlocks.Length < 4 || lSystemBlocks.Length > 4) throw new ArgumentException(nameof(lSystem));

    //        string varBlock = lSystemBlocks[0];
    //        string constBlock = lSystemBlocks[1];
    //        string startBlock = lSystemBlocks[2];
    //        string rulesBlock = lSystemBlocks[3];

    //        IEnumerable<LVariable> variables = GetVariablesFromString(varBlock, rulesBlock);
    //        IEnumerable<LConst> consts = GetConstsFromString(constBlock);
    //        Operations operands 
    //            = new Operations(variables.Cast<LOperations>().Concat(consts).ToDictionary(p => p.Name));

    //        LRules start = GetStartFromString(operands, startBlock);
    //        Expressions expressions 
    //            = new Expressions(GetExpressionsFromString(operands, rulesBlock));

    //        LSystem result = new LSystem()
    //        {
    //            Operations = operands,
    //            Axiom = start,
    //            Expression = expressions
    //        };

    //        return result;
    //    }

    //    private LRules GetStartFromString(Dictionary<char, LOperations> operands, string startBlock)
    //    {
    //        return GetExpressionFromString(operands, startBlock);
    //    }

    //    private LRules GetExpressionFromString(IDictionary<char, LOperations> operads, string expr)
    //    {
    //        var arr = expr.Split(new[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries);
    //        if (arr.Length == 1)
    //        {
    //            return new LRules()
    //            {
    //                From = null,
    //                To = arr[0].Select(p => operads[p]).ToList()
    //            };
    //        }
    //        else if (arr.Length == 2)
    //        {
    //            if (operads.TryGetValue(arr[0][0], out LOperations fromOper) && fromOper is LVariable fromVar)
    //            {
    //                return new LRules()
    //                {
    //                    From = (LVariable)fromVar,
    //                    To = arr[1].Select(p => operads[p]).ToList()
    //                };
    //            }
    //            else
    //            {
    //                throw new ArgumentException("Can't parse expression name");
    //            }
    //        }
    //        else
    //        {
    //            throw new Exception();
    //        }
    //    }

    //    private Dictionary<char, LRules> GetExpressionsFromString(Dictionary<char, LOperations> operands, string rulesBlock)
    //    {
    //        var b = rulesBlock.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //        var a = b.Select(p => GetExpressionFromString(operands, p)).ToList();
    //        return a.ToDictionary(p => p.From);
    //    }

    //    private IEnumerable<char> GetVariablesFromString(string varBlock, string rulesBlock)
    //    {
    //        return varBlock.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p[0]);
    //    }

    //    private IEnumerable<LConst> GetConstsFromString(string block)
    //    {
    //        return block.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(p => new LConst() { Name = p[0] });
    //    }

    //    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //    {
    //        if (sourceType == typeof(string)) return true;
    //        return base.CanConvertFrom(context, sourceType);
    //    }

    //    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //    {
    //        if (destinationType == typeof(LSystem)) return true;
    //        return base.CanConvertTo(context, destinationType);
    //    }

    //    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    //    {
    //        switch (value)
    //        {
    //            case string str:
    //                return ConvertFromString(culture, str);

    //            default:
    //                throw new ArgumentOutOfRangeException("Value type");
    //        }
    //    }

    //    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //    {
    //        return base.ConvertTo(context, culture, value, destinationType);
    //    }

    //    public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
    //    {
    //        return base.CreateInstance(context, propertyValues);
    //    }

    //    public override bool IsValid(ITypeDescriptorContext context, object value)
    //    {
    //        return base.IsValid(context, value);
    //    }
    //}
}