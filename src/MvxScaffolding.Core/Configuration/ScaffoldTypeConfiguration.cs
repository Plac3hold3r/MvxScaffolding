//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MvxScaffolding.Core.Configuration
{
    public class PlatformScaffoldTypeConfiguration
    {
        public List<ScaffoldTypeConfiguration> MvxNative { get; set; }

        public List<ScaffoldTypeConfiguration> MvxForms { get; set; }

        public class ScaffoldTypeConfiguration
        {
            public ScaffoldType Type { get; set; }

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public List<PlatformType> Platforms { get; set; }

            public List<TemplateOptionKey> Exclude { get; set; }

            public class TemplateOptionKey
            {
                public string OptionName { get; set; }

                public string Optionkey { get; set; }
            }
        }
    }
}
