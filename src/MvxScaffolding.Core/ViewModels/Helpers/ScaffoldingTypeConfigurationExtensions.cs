//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.ViewModels.Helpers
{
    internal static class ScaffoldingTypeConfigurationExtensions
    {
        internal static List<ScaffoldTemplateOptionViewModel> ToScaffoldTemplateOptions(this PlatformScaffoldTypeConfiguration platformScaffoldTypeConfiguration, TemplateType currentTemplateType)
        {
            var templateOptions = new List<ScaffoldTemplateOptionViewModel>();

            if (currentTemplateType == TemplateType.MvxNative)
            {
                foreach (PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration scaffoldTemplate in platformScaffoldTypeConfiguration.MvxNative)
                {
                    var newTemplate = ScaffoldTemplateOptionViewModel.Create(scaffoldTemplate.Type);
                    newTemplate.HasAndroid = scaffoldTemplate.Platforms.Contains(PlatformType.Android);
                    newTemplate.HasIos = scaffoldTemplate.Platforms.Contains(PlatformType.Ios);
                    newTemplate.HasUwp = scaffoldTemplate.Platforms.Contains(PlatformType.Uwp);
                    newTemplate.Exclude = scaffoldTemplate.Exclude;

                    templateOptions.Add(newTemplate);
                }
            }

            return templateOptions;
        }
    }
}
