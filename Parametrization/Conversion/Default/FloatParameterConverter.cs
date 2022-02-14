using System;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class FloatParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is float s ?$"{s}" : $"{DefaultValue()}";

        public override object Parse(string value) => float.TryParse(value, out var s) ? s : DefaultValue();
        public override bool CanParse(string value, out string errorMessage)
        {
            errorMessage = "";
            var ret = float.TryParse(value, out _);
            if (!ret) errorMessage = "The provided value does not represent a Float";
            return ret;
        }

        public FloatParameterConverter() : base(typeof(float))
        {
        }
    }
}