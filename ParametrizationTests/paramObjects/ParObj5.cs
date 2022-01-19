using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public class ParObj5 : ParObj3
    {
        [ParameterDefinition(typeof(string), "A string Parameter for testing purposes of ParObj5", "me lene popi")]
        public string DefaultString { get; set; }
    }
}