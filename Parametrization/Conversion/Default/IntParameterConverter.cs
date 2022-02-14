using System;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class IntParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is int s ?$"{s}" : $"{DefaultValue()}";

        public override object Parse(string value) => int.TryParse(value, out var s) ? s : DefaultValue();
        public override bool CanParse(string value, out string errorMessage)
        {
            errorMessage = "";
            var ret = int.TryParse(value, out _);
            if (!ret) errorMessage = "The provided value does not represent an Integer";
            return ret;
        }

        public IntParameterConverter() : base(typeof(int))
        {
        }
    }
}