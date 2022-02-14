using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class JsonParameterConverter : ParameterConverter
    {
        public override string Serialize(object value)
        {
            try
            {
                var jObj = JToken.FromObject(value);
                return jObj.ToString();
            }
            catch
            {
                try
                {
                    var jObj = JToken.FromObject(DefaultValue());
                    return jObj.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public override object Parse(string value)
        {
            try
            {
                var jObj = JToken.Parse(value);
                return jObj.ToObject(OutputType) ?? DefaultValue();
            }
            catch
            {
                return DefaultValue();
            }
        }

        public override bool CanParse(string value, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                var jObj = JToken.Parse(value);
                var op = jObj.ToObject(OutputType);
                if (op is not null && OutputType.IsInstanceOfType(op)) return true;
                errorMessage = "The provided string does not resemble a valid Json struct"
                return false;
            }
            catch
            {
                return false;
            }
        }

        public JsonParameterConverter([NotNull] Type outputType) : base(outputType)
        {
        }
    }
}