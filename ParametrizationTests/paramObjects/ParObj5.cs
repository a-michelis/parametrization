using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public enum TestType
    {
        Type1, Type2, Type3, Type4, Type5
    }

    public class ParObj5 : ParObj3
    {
        [ParameterDefinition(typeof(string), "A string Parameter for testing purposes of ParObj5", "me lene popi")]
        public string DefaultString { get; set; }

        [ParameterDefinition(typeof(TestType), "Enum Test Parameter", "0")]
        private TestType Test { get; set; }
    }
}