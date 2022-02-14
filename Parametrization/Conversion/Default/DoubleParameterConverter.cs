namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class DoubleParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is double s ?$"{s}" : $"{DefaultValue()}";

        public override object Parse(string value) => double.TryParse(value, out var s) ? s : DefaultValue();
        public override bool CanParse(string value, out string errorMessage)
        {
            errorMessage = "";
            var ret = double.TryParse(value, out _);
            if (!ret) errorMessage = "The provided value does not represent a Double";
            return ret;
        }

        public DoubleParameterConverter() : base(typeof(double))
        {
        }
    }
}