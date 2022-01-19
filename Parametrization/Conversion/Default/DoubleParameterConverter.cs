namespace AndreasMichelis.Parametrization.Conversion.Default
{
    public class DoubleParameterConverter : ParameterConverter
    {
        public override string Serialize(object value) => value is double s ?$"{s}" : $"{DefaultValue()}";

        public override object Parse(string value) => double.TryParse(value, out var s) ? s : DefaultValue();
        public override bool CanParse(string value) => double.TryParse(value, out _);

        public DoubleParameterConverter() : base(typeof(double))
        {
        }
    }
}