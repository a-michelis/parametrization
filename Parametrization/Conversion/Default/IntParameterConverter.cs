using System;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class IntParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is int s ?$"{s}" : $"{DefaultValue()}";

        public override object Parse(string value) => int.TryParse(value, out var s) ? s : DefaultValue();
        public override bool CanParse(string value) => int.TryParse(value, out _);

        public IntParameterConverter() : base(typeof(int))
        {
        }
    }
}