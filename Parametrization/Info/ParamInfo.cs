#nullable enable
using System;
using AndreasMichelis.Parametrization.Conversion;

namespace AndreasMichelis.Parametrization.Info
{
    public class ParamInfo
    {
        internal ParamInfo(string name, string description, string defaultValue, Type paramType, ParameterConverter converter)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
            ParamType = paramType;
            Converter = converter;
        }

        public string Name { get; }
        public string Description { get; }
        public string DefaultValue { get; }
        public Type ParamType { get; }
        public ParameterConverter Converter { get; }
    }
}
