using System;

namespace MvxScaffolding.UI.Helpers
{
    /// <summary>
    /// Add references to assemblies that are not referenced in code in order to have Visual Studio include them in dependencies projects
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ForceAssemblyReferenceAttribute : Attribute
    {
        public ForceAssemblyReferenceAttribute(Type forcedType)
        {
            Action<Type> noop = _ => { };
            noop(forcedType);
        }
    }
}
