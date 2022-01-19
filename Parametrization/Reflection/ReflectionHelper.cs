#nullable enable
using System;
using System.Linq;
using System.Reflection;
using AndreasMichelis.Parametrization.Attributes;
using AndreasMichelis.Parametrization.Info;

namespace AndreasMichelis.Parametrization.Reflection
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Describes whether the specified type is Parametric
        /// </summary>
        /// <param name="type"></param>
        /// <returns>True if the type is not abstract and derives from <see cref="ParametricObject"/>. False otherwise</returns>
        public static bool IsParametric(this Type type) 
            => type is { IsAbstract: false } && type.IsAssignableTo(typeof(ParametricObject));

        /// <summary>
        /// Retrieves a list of <see cref="ParamInfo"/> representing this type's parameters
        /// </summary>
        /// <param name="type">The desired type to be searched</param>
        /// <returns>Null if the type is abstract or not derived from <see cref="ParametricObject"/>. The retrieved list, otherwise</returns>
        public static ParamInfo[]? GetParameters(this Type type)
        {
            if (!type.IsParametric()) return null;

            return type.GetProperties(ParametricObject.BFlags)
                .Select(pi => pi.GetCustomAttributes<ParameterDefinitionAttribute>(true).FirstOrDefault() is { } pd
                    ? new ParamInfo(pi.Name, pd.Description, pd.DefaultValue, pd.ParamType, pd.Converter)
                    : null)
                .Where(x => x is not null)
                .ToArray()!;
        }
    }
}
