//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;

namespace MvxScaffolding.UI.Utils
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ForceAssemblyReferenceAttribute : Attribute
    {
        public ForceAssemblyReferenceAttribute(Type forcedType)
        {
            void noop(Type _) { /* Method intentionally left empty */ }
            noop(forcedType);
        }
    }
}
