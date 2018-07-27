//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace MvxScaffolding.Core.Template
{
    public enum PlatformType
    {
        Android,
        [EnumMember(Value = "iOS")]
        Ios,
        [EnumMember(Value = "UWP")]
        Uwp
    }
}
