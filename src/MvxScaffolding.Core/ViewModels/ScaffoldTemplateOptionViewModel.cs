//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Localization.Resources;
using static MvxScaffolding.Core.Configuration.PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration;

namespace MvxScaffolding.Core.ViewModels
{
    public class ScaffoldTemplateOptionViewModel : BaseViewModel
    {
        public ScaffoldType ScaffoldType { get; set; }

        public string HeaderName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasAndroid { get; set; }

        public bool HasIos { get; set; }

        public bool HasUwp { get; set; }

        public bool IsSelected { get; set; }

        internal List<TemplateOptionKey> Exclude { get; set; }

        public static ScaffoldTemplateOptionViewModel Create(ScaffoldType scaffoldType)
        {
            switch (scaffoldType)
            {
                case ScaffoldType.SingleView:
                    return new ScaffoldTemplateOptionViewModel
                    {
                        HeaderName = "SV",
                        ScaffoldType = ScaffoldType.SingleView,
                        Name = LocalResources.AppDetails_Template_SingleView,
                        Description = LocalResources.AppDetails_Template_SingleView_Description,
                        IsSelected = true
                    };
                case ScaffoldType.NavigationMenu:
                    return new ScaffoldTemplateOptionViewModel
                    {
                        HeaderName = "NM",
                        ScaffoldType = ScaffoldType.NavigationMenu,
                        Name = LocalResources.AppDetails_Template_NavigationMenu,
                        Description = LocalResources.AppDetails_Template_NavigationMenu_Description,
                        IsSelected = false
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(scaffoldType), $"No matching {nameof(ScaffoldType)} found for {scaffoldType}");
            }
        }
    }
}
