//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;
using static MvxScaffolding.Core.Configuration.PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration;

namespace MvxScaffolding.Core.ViewModels.Helpers
{
    internal static class ScaffoldingTypeConfigurationExtensions
    {
        internal static List<ScaffoldTemplateOptionViewModel> ToScaffoldTemplateOptions(
            this PlatformScaffoldTypeConfiguration platformScaffoldTypeConfiguration,
            TemplateType currentTemplateType,
            WizardOptionViewModel options)
        {
            var templateOptions = new List<ScaffoldTemplateOptionViewModel>();

            if (currentTemplateType == TemplateType.MvxNative)
            {
                foreach (PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration scaffoldTemplate in platformScaffoldTypeConfiguration.MvxNative)
                {
                    templateOptions.Add(scaffoldTemplate.MapScaffoldTemlateOption(options));
                }
            }
            else if (currentTemplateType == TemplateType.MvxForms)
            {
                foreach (PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration scaffoldTemplate in platformScaffoldTypeConfiguration.MvxForms)
                {
                    templateOptions.Add(scaffoldTemplate.MapScaffoldTemlateOption(options));
                }
            }

            return templateOptions;
        }

        internal static ScaffoldTemplateOptionViewModel MapScaffoldTemlateOption(
            this PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration scaffoldTemplate,
            WizardOptionViewModel options)
        {
            var newTemplate = ScaffoldTemplateOptionViewModel.Create(scaffoldTemplate.Type, options);
            newTemplate.HasAndroidSupport = scaffoldTemplate.Platforms.Contains(PlatformType.Android);
            newTemplate.HasIosSupport = scaffoldTemplate.Platforms.Contains(PlatformType.Ios);
            newTemplate.HasUwpSupport = scaffoldTemplate.Platforms.Contains(PlatformType.Uwp);
            newTemplate.Exclude = scaffoldTemplate.Exclude ?? new List<TemplateOptionKey>();

            return newTemplate;
        }

        internal static Dictionary<string, string> Filter(this Dictionary<string, string> options, List<TemplateOptionKey> excludedOptions)
        {
            foreach (var excludeItem in excludedOptions)
            {
                options.Remove(excludeItem.Optionkey);
            }

            return options;
        }
    }
}
