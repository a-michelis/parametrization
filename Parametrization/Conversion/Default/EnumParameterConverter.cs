using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class EnumParameterConverter : ParameterConverter
    {
        private class EnumDescriptor
        {
            public string Name { get; }
            public int Id { get; }

            public EnumDescriptor(string name, int id)
            {
                Name = name;
                Id = id;
            }
        }
        private readonly EnumDescriptor[] _allValues;

        public override object Parse(string value)
        {
            if (int.TryParse(value, out var i) 
                && _allValues.FirstOrDefault(x => x.Id == i) is {} a)
                return Enum.ToObject(OutputType, a.Id);

            return _allValues.FirstOrDefault(x => x.Name == value) is { } b
                ? Enum.ToObject(OutputType, b.Id)
                : DefaultValue();
        }

        public override bool CanParse(string value)
        {
            if (int.TryParse(value, out var i) && _allValues.Any(x => x.Id == i))
            {
                return true;
            }

            return _allValues.Any(x => x.Name == value);
        }

        public override string Serialize(object value)
        {
            if (!OutputType.IsInstanceOfType(value)) return DefaultValue().ToString();
            var v = Convert.ToInt32(value);
            if (_allValues.FirstOrDefault(x => x.Id == v) is { } a) return a.Name;
            return DefaultValue().ToString();
        }

        public EnumParameterConverter([NotNull] Type outputType) : base(outputType)
        {
            if (!outputType.IsEnum)
                throw new InvalidCastException("EnumParameterConverter can only be used with Enum types");

            _allValues = GetEnumList(outputType);
        }


        private static EnumDescriptor[] GetEnumList(Type T)
        {
            if (!T.IsEnum) return Array.Empty<EnumDescriptor>();
            return Enum.GetValues(T)
                .Cast<int>()
                .Select(val => new EnumDescriptor(Enum.GetName(T, val), val))
                .ToArray();
        }
    }
}
