using System;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class StringParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is string s ? s : "";

        public override object Parse(string value) => value;
        public override bool CanParse(string value, out string errorMessage)
        {
            errorMessage = "";
            return true;
        }

        public StringParameterConverter() : base(typeof(string))
        {
        }
    }
}