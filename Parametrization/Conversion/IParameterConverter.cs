using System;
using System.Diagnostics.CodeAnalysis;

namespace AndreasMichelis.Parametrization.Conversion
{
    public abstract class ParameterConverter
    {
        /// <summary>
        /// The desired output type of the converter (Used to TypeCheck and Get Default Value in case of error
        /// </summary>
        protected Type OutputType { get; }

        /// <summary>
        /// Convert a parameter's value into string
        /// </summary>
        /// <param name="value">The parameter's value</param>
        /// <returns>The serialized parameter's value or the serialized form of Output Type's Default Value, if something went wrong</returns>
        public abstract string Serialize(object value);

        /// <summary>
        /// Convert a parameter's serialized value into actual value
        /// </summary>
        /// <param name="value">The parameter's serialized value</param>
        /// <returns>The DeSerialized parameter's value or the Output Type's Default Value, if something went wrong</returns>
        public abstract object Parse(string value);

        /// <summary>
        /// Tests if a given serialized value is syntactically able to be parsed (a.k.a. contains no errors)
        /// </summary>
        /// <param name="value">The desired serialized value</param>
        /// <returns>True if the test-parsing was successful, false otherwise</returns>
        public abstract bool CanParse(string value, out string errorMessage);

        /// <summary>
        /// Retrieves or recreates the Output Type's default Value
        /// </summary>
        /// <returns>The Output Type's default Value</returns>
        protected object DefaultValue() => OutputType.IsValueType ? Activator.CreateInstance(OutputType) : null;


        protected ParameterConverter([NotNull] Type outputType) => OutputType = outputType;

    }
}