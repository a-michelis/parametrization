#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
using AndreasMichelis.Parametrization.Conversion;
using AndreasMichelis.Parametrization.Conversion.Default;

namespace AndreasMichelis.Parametrization.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterDefinitionAttribute : Attribute
    {
        public ParameterConverter Converter { get; }
        public Type ParamType { get; }
        public string Description { get; }
        public string DefaultValue { get; }

        /// <summary>
        /// Defines that the following property is a parameter with one of the default converters as its converter
        /// </summary>
        /// <param name="paramType">The property's type</param>
        /// <param name="description">An optional description</param>
        /// <param name="defaultValue">the property's default value</param>
        public ParameterDefinitionAttribute(Type paramType, string description, string defaultValue)
        {
            ParamType = paramType;
            Description = description;
            DefaultValue = defaultValue;

            if (paramType == typeof(int))         Converter = new IntParameterConverter();
            else if (paramType == typeof(float))  Converter = new FloatParameterConverter();
            else if (paramType == typeof(double)) Converter = new DoubleParameterConverter();
            else if (paramType == typeof(string)) Converter = new StringParameterConverter();
            else                                  Converter = new JsonParameterConverter(paramType);

        }

        /// <summary>
        /// Defines that the following property is a parameter with converter of the defined type as its converter
        /// If the converter type provided does not derive from <see cref="ParameterConverter"/> or the instantiation fails,
        /// the Parameter uses one of the default converters instead, without a warning.
        /// </summary>
        /// <param name="paramType">The property's type</param>
        /// <param name="description">An optional description</param>
        /// <param name="defaultValue">the property's default value</param>
        /// <param name="converterType">The converter's type</param>
        /// <param name="converterCtorArgs">an optional list of construction arguments needed to instantiate a new converter</param>
        public ParameterDefinitionAttribute(Type paramType, string description, string defaultValue, Type converterType, params object?[]? converterCtorArgs)
        {
            ParamType = paramType;
            Description = description;
            DefaultValue = defaultValue;

            ParameterConverter defaultConverter;
            if (paramType == typeof(int))         defaultConverter = new IntParameterConverter();
            else if (paramType == typeof(float))  defaultConverter = new FloatParameterConverter();
            else if (paramType == typeof(double)) defaultConverter = new DoubleParameterConverter();
            else if (paramType == typeof(string)) defaultConverter = new StringParameterConverter();
            else                                  defaultConverter = new JsonParameterConverter(paramType);

            if (!converterType.IsAssignableTo(typeof(ParameterConverter)))
            {
                Converter = defaultConverter;
                return;
            }

            ParameterConverter? newConverter;

            if (converterCtorArgs is { Length: > 0 })
            {
                try { newConverter = Activator.CreateInstance(converterType, converterCtorArgs) as ParameterConverter ?? defaultConverter; }
                catch { newConverter = defaultConverter; }
            }
            else
            {
                try { newConverter = Activator.CreateInstance(converterType) as ParameterConverter ?? defaultConverter; }
                catch { newConverter = defaultConverter; }
            }

            Converter = newConverter;
        }
    }
}