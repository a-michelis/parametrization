using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public class ParObj4 : ParObj3
    {
        [ParameterDefinition(typeof(float), "An overriden float Parameter (from ParObj3) for testing purposes of ParObj4", "1.5")]
        public override float DefaultFloat { get; set; }
    }
}