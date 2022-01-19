using AndreasMichelis.Parametrization;
using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public abstract class ParObj3 : ParametricObject
    {
        [ParameterDefinition(typeof(float), "A virtual float Parameter for testing purposes of ParObj3", "0.93")]
        public virtual float DefaultFloat { get; set; }
    }
}