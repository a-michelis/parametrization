using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public class ParObj2 : ParObj1
    {
        [ParameterDefinition(typeof(float), "A Float Parameter for testing purposes of ParObj2", "0.93")]
        public float DefaultFloat { get; set; }
    }
}