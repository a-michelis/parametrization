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

        public override bool CanParse(string value)
        {
            try
            {
                var jObj = JToken.Parse(value);
                var op = jObj.ToObject(OutputType);
                return op is not null;
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