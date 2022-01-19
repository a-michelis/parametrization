using System;
using System.Linq;
using System.Reflection;
using AndreasMichelis.Parametrization.Info;
using AndreasMichelis.Parametrization.Reflection;

namespace AndreasMichelis.Parametrization
{
    public abstract class ParametricObject
    {
        private readonly ParamInfo[] _parameters;

        internal static readonly BindingFlags BFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        protected ParametricObject()
        {
            _parameters = this.GetType().GetParameters() ?? Array.Empty<ParamInfo>();

            foreach (var parameter in _parameters)
            { 
                try
                {
                    var val = parameter.Converter.Parse(parameter.DefaultValue);
                    this.GetType().GetProperty(parameter.Name, BFlags)?.SetValue(this, val);
                }
                catch { /* ignored */ }
            }
        }

        /// <summary>
        /// Gets the value of the parameter with the specified name
        /// </summary>
        /// <param name="paramName">Parameter's name</param>
        /// <returns>If the parameter exists and can be retrieved, the parameter's value. Null otherwise</returns>
        public object GetParameter(string paramName)
        {
            var pi = _parameters.FirstOrDefault(x => x.Name == paramName);
            if (pi is null) return null;
            try { return this.GetType().GetProperty(paramName, BFlags)?.GetValue(this); }
            catch { return null; }
        }

        /// <summary>
        /// Sets the value of the parameter with the specified name
        /// </summary>
        /// <param name="paramName">Parameter's name</param>
        /// <param name="paramValue">The desired Value</param>
        public void SetParameter(string paramName, object paramValue)
        {
            var pi = _parameters.FirstOrDefault(x => x.Name == paramName);
            if (pi is null) return;
            try { this.GetType().GetProperty(paramName, BFlags)?.SetValue(this, paramValue); }
            catch { /* ignored */ }
        }

        /// <summary>
        /// Gets the serialized value of the parameter with the specified name
        /// </summary>
        /// <param name="paramName">Parameter's name</param>
        /// <returns></returns>
        public string SerializeParameter(string paramName)
        {
            var pi = _parameters.FirstOrDefault(x => x.Name == paramName);
            if (pi is null) return null;
            try
            {
                var val = this.GetType().GetProperty(paramName, BFlags)?.GetValue(this);
                return pi.Converter.Serialize(val);
            }
            catch { return ""; }
        }

        /// <summary>
        /// Parses the provided serialized value and sets it on the parameter with the specified name
        /// </summary>
        /// <param name="paramName">Parameter's name</param>
        /// <param name="paramValue">The desired serialized Value to be parsed</param>
        public void ParseParameter(string paramName, string paramValue)
        {
            var pi = _parameters.FirstOrDefault(x => x.Name == paramName);
            if (pi is null) return;
            try
            {
                var val = pi.Converter.Parse(paramValue);
                this.GetType().GetProperty(paramName, BFlags)?.SetValue(this, val);
            }
            catch { /* ignored */ }
        }
    }
}
