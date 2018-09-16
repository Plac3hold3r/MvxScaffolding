//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Localization.Resources;
using static MvxScaffolding.Core.Configuration.PlatformScaffoldTypeConfiguration.ScaffoldTypeConfiguration;

namespace MvxScaffolding.Core.ViewModels
{
    public class ScaffoldTemplateOptionViewModel : BaseViewModel
    {
        public ICommand SelectScaffoldTypeCommand { get; }

        public ScaffoldType ScaffoldType { get; set; }

        public string HeaderName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasAndroidSupport { get; set; }

        public bool HasIosSupport { get; set; }

        public bool HasUwpSupport { get; set; }

        bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        internal List<TemplateOptionKey> Exclude { get; set; }

        internal WizardOptionViewModel Options { get; }

        public ScaffoldTemplateOptionViewModel(WizardOptionViewModel options)
        {
            Options = options;

            SelectScaffoldTypeCommand = new RelayCommand(SelectScaffoldType);
        }

        public static ScaffoldTemplateOptionViewModel Create(ScaffoldType scaffoldType, WizardOptionViewModel options)
        {
            switch (scaffoldType)
            {
                case ScaffoldType.SingleView:
                    return new ScaffoldTemplateOptionViewModel(options)
                    {
                        HeaderName = "SV",
                        ScaffoldType = ScaffoldType.SingleView,
                        Name = LocalResources.AppDetails_Template_SingleView,
                        Description = LocalResources.AppDetails_Template_SingleView_Description,
                        IsSelected = false
                    };
                case ScaffoldType.NavigationMenu:
                    return new ScaffoldTemplateOptionViewModel(options)
                    {
                        HeaderName = "NM",
                        ScaffoldType = ScaffoldType.NavigationMenu,
                        Name = LocalResources.AppDetails_Template_NavigationMenu,
                        Description = LocalResources.AppDetails_Template_NavigationMenu_Description,
                        IsSelected = false
                    };
                case ScaffoldType.Blank:
                    return new ScaffoldTemplateOptionViewModel(options)
                    {
                        HeaderName = "B",
                        ScaffoldType = ScaffoldType.Blank,
                        Name = LocalResources.AppDetails_Template_Blank,
                        Description = LocalResources.AppDetails_Template_Blank_Description,
                        IsSelected = false
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(scaffoldType), $"No matching {nameof(ScaffoldType)} found for {scaffoldType}");
            }
        }

        void SelectScaffoldType()
        {
            Options.SelectedScaffoldType.IsSelected = false;
            Options.SelectedScaffoldType = this;
            Options.SelectedScaffoldType.IsSelected = true;
        }
    }
}
