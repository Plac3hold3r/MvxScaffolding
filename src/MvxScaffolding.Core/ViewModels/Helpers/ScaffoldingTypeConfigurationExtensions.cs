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
            newTemplate.HasAndroid = scaffoldTemplate.Platforms.Contains(PlatformType.Android);
            newTemplate.HasIos = scaffoldTemplate.Platforms.Contains(PlatformType.Ios);
            newTemplate.HasUwp = scaffoldTemplate.Platforms.Contains(PlatformType.Uwp);
            newTemplate.Exclude = scaffoldTemplate.Exclude;

            return newTemplate;
        }
    }
}
