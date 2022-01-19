using AndreasMichelis.Parametrization;
using AndreasMichelis.Parametrization.Attributes;

namespace ParametrizationTests.paramObjects
{
    public class ParObj1 : ParametricObject
    {
        [ParameterDefinition(typeof(int), "An Integer Parameter for testing purposes of ParObj1", "12")]
        public int DefaultInt { get; set; }
    }
}