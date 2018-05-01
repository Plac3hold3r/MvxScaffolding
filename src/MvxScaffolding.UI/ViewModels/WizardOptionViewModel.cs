//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Localization.Resources;
using MvxScaffolding.UI.Validation;

namespace MvxScaffolding.UI.ViewModels
{
    public class WizardOptionViewModel : BaseViewModel, ITemplateOptions, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, ICollection<string>>
            _validationErrors = new Dictionary<string, ICollection<string>>();

        private string _appName;
        [Required(ErrorMessageResourceName = nameof(LocalResources.AppDetails_Validation_Display_Name), ErrorMessageResourceType = typeof(LocalResources))]
        public string AppName
        {
            get => _appName;
            set
            {
                _appName = value;
                OnPropertyChanged(nameof(AppName));
                ValidateModelProperty(value, nameof(AppName));
            }
        }

        private string _appId;
        [Required(ErrorMessageResourceName = nameof(LocalResources.AppDetails_Validation_Identifier), ErrorMessageResourceType = typeof(LocalResources))]
        public string AppId
        {
            get => _appId;
            set
            {
                _appId = value;
                OnPropertyChanged(nameof(AppId));
                ValidateModelProperty(value, nameof(AppId));
            }
        }

        private string _selectedMvvmCrossVersion;

        public string SelectedMvvmCrossVersion
        {
            get => _selectedMvvmCrossVersion;
            set { _selectedMvvmCrossVersion = value; OnPropertyChanged(nameof(SelectedMvvmCrossVersion)); }
        }

        public Dictionary<string, string> MvvmCrossVersionOptions { get; }

        private bool _hasEditorConfig;

        public bool HasEditorConfig
        {
            get => _hasEditorConfig;
            set { _hasEditorConfig = value; OnPropertyChanged(nameof(HasEditorConfig)); }
        }

        private string _selectedProjectGrouping;

        public string SelectedProjectGrouping
        {
            get => _selectedProjectGrouping;
            set { _selectedProjectGrouping = value; OnPropertyChanged(nameof(SelectedProjectGrouping)); }
        }

        public Dictionary<string, string> ProjectGroupingOptions { get; }

        private string _selectedNetStandard;

        public string SelectedNetStandard
        {
            get => _selectedNetStandard;
            set { _selectedNetStandard = value; OnPropertyChanged(nameof(SelectedNetStandard)); }
        }

        public Dictionary<string, string> NetStandardOptions { get; }

        private bool _hasCoreUnitTestProject;

        public bool HasCoreUnitTestProject
        {
            get => _hasCoreUnitTestProject;
            set { _hasCoreUnitTestProject = value; OnPropertyChanged(nameof(HasCoreUnitTestProject)); }
        }

        private string _selectedMinAndroidSDK;

        public string SelectedMinAndroidSDK
        {
            get => _selectedMinAndroidSDK;
            set { _selectedMinAndroidSDK = value; OnPropertyChanged(nameof(SelectedMinAndroidSDK)); }
        }

        public Dictionary<string, string> MinAndroidSDKOptions { get; }

        private bool _hasAndroidUnitTestProject;

        public bool HasAndroidUnitTestProject
        {
            get => _hasAndroidUnitTestProject;
            set { _hasAndroidUnitTestProject = value; OnPropertyChanged(nameof(HasAndroidUnitTestProject)); }
        }

        private bool _hasAndroidUiTestProject;

        public bool HasAndroidUiTestProject
        {
            get => _hasAndroidUiTestProject;
            set
            {
                if (SetProperty(ref _hasAndroidUiTestProject, value) && IsFormsTemplate)
                {
                    HasIosUiTestProject = value;
                }
            }
        }

        private bool _hasAndroidXml;

        public bool HasAndroidXml
        {
            get => _hasAndroidXml;
            set { _hasAndroidXml = value; OnPropertyChanged(nameof(HasAndroidXml)); }
        }

        private string _selectedMinIosSDK;

        public string SelectedMinIosSDK
        {
            get => _selectedMinIosSDK;
            set { _selectedMinIosSDK = value; OnPropertyChanged(nameof(SelectedMinIosSDK)); }
        }

        public Dictionary<string, string> MinIosSDKOptions { get; }

        private bool _hasIosUnitTestProject;

        public bool HasIosUnitTestProject
        {
            get => _hasIosUnitTestProject;
            set { _hasIosUnitTestProject = value; OnPropertyChanged(nameof(HasIosUnitTestProject)); }
        }

        private bool _hasIosUiTestProject;

        public bool HasIosUiTestProject
        {
            get => _hasIosUiTestProject;
            set
            {
                if (SetProperty(ref _hasIosUiTestProject, value) && IsFormsTemplate)
                {
                    HasAndroidUiTestProject = value;
                }
            }
        }

        private bool _hasIosFluentLayout;

        public bool HasIosFluentLayout
        {
            get => _hasIosFluentLayout;
            set { _hasIosFluentLayout = value; OnPropertyChanged(nameof(HasIosFluentLayout)); }
        }

        private bool _hasIosHyperion;

        public bool HasIosHyperion
        {
            get => _hasIosHyperion;
            set { _hasIosHyperion = value; OnPropertyChanged(nameof(HasIosHyperion)); }
        }

        private string _uwpDescription;
        [RequiredIf(nameof(HasUwp), true, ErrorMessageResourceName = nameof(LocalResources.PlatformOptions_Validation_Uwp_Description), ErrorMessageResourceType = typeof(LocalResources))]
        public string UwpDescription
        {
            get => _uwpDescription;
            set
            {
                _uwpDescription = value;
                OnPropertyChanged(nameof(UwpDescription));
                ValidateModelProperty(value, nameof(UwpDescription));
            }
        }

        private string _selectedMinUwpSDK;

        public string SelectedMinUwpSDK
        {
            get => _selectedMinUwpSDK;
            set { _selectedMinUwpSDK = value; OnPropertyChanged(nameof(SelectedMinUwpSDK)); }
        }

        public Dictionary<string, string> MinUwpSDKOptions { get; }

        private bool _hasUwpUnitTestProject;

        public bool HasUwpUnitTestProject
        {
            get => _hasUwpUnitTestProject;
            set { _hasUwpUnitTestProject = value; OnPropertyChanged(nameof(HasUwpUnitTestProject)); }
        }

        private bool _hasUwpUiTestProject;

        public bool HasUwpUiTestProject
        {
            get => _hasUwpUiTestProject;
            set { _hasUwpUiTestProject = value; OnPropertyChanged(nameof(HasUwpUiTestProject)); }
        }

        private bool _hasAndroid;

        public bool HasAndroid
        {
            get => _hasAndroid;
            set { _hasAndroid = value; OnPropertyChanged(nameof(HasAndroid)); }
        }

        private PackIconKind _androidIncludeIcon;

        public PackIconKind AndroidIncludeIcon
        {
            get => _androidIncludeIcon;
            set { _androidIncludeIcon = value; OnPropertyChanged(nameof(AndroidIncludeIcon)); }
        }

        private bool _hasIos;

        public bool HasIos
        {
            get => _hasIos;
            set { _hasIos = value; OnPropertyChanged(nameof(HasIos)); }
        }

        private PackIconKind _iosIncludeIcon;

        public PackIconKind IosIncludeIcon
        {
            get => _iosIncludeIcon;
            set { _iosIncludeIcon = value; OnPropertyChanged(nameof(IosIncludeIcon)); }
        }

        private bool _hasUwp;

        public bool HasUwp
        {
            get => _hasUwp;
            set
            {
                _hasUwp = value;
                OnPropertyChanged(nameof(HasUwp));
                if (!value)
                    ValidateModelProperty(value, nameof(UwpDescription));
            }
        }

        private PackIconKind _uwpIncludeIcon;

        public PackIconKind UwpIncludeIcon
        {
            get => _uwpIncludeIcon;
            set { _uwpIncludeIcon = value; OnPropertyChanged(nameof(UwpIncludeIcon)); }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool HasErrors
            => _validationErrors.Count > 0;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
            || !_validationErrors.ContainsKey(propertyName))
                return new Collection<string>();

            return _validationErrors[propertyName];
        }

        public void ValidateModelProperty(object value, string propertyName)
        {
            if (_validationErrors.ContainsKey(propertyName))
                _validationErrors.Remove(propertyName);

            PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
            IList<string> validationErrors =
                  (from validationAttribute in propertyInfo.GetCustomAttributes(true).OfType<ValidationAttribute>()
                   where validationAttribute.GetValidationResult(value, new ValidationContext(this)) != ValidationResult.Success
                   select validationAttribute.FormatErrorMessage(string.Empty))
                   .ToList();

            if (validationErrors.Count != 0)
                _validationErrors.Add(propertyName, validationErrors);

            RaiseErrorsChanged(propertyName);
        }

        public WizardOptionViewModel()
        {
            ProjectGroupingOptions = TemplateChoices.ProjectGroupingOptions;
            SelectedProjectGrouping = TemplateChoices.ProjectGroupingOptionDefault;

            MvvmCrossVersionOptions = TemplateChoices.MvvmCrossVersionOptions;
            SelectedMvvmCrossVersion = TemplateChoices.MvvmCrossVersionOptionDefault;

            HasEditorConfig = true;

            NetStandardOptions = TemplateChoices.NetStandardOptions;
            SelectedNetStandard = TemplateChoices.NetStandardOptionDefault;

            HasCoreUnitTestProject = false;

            MinAndroidSDKOptions = TemplateChoices.MinAndroidSDKOptions;
            SelectedMinAndroidSDK = TemplateChoices.MinAndroidSDKOptionDefault;

            HasAndroidUnitTestProject = false;
            HasAndroidUiTestProject = false;
            HasAndroidXml = false;

            MinIosSDKOptions = TemplateChoices.MinIosSDKOptions;
            SelectedMinIosSDK = TemplateChoices.MinIosSDKOptionDefault;

            HasIosUnitTestProject = false;
            HasIosUiTestProject = false;
            HasIosFluentLayout = false;
            HasIosHyperion = false;

            MinUwpSDKOptions = TemplateChoices.MinUwpSDKOptions;
            SelectedMinUwpSDK = TemplateChoices.MinUwpSDKOptionDefault;

            HasUwpUnitTestProject = false;
            HasUwpUiTestProject = false;

            HasAndroid = true;
            AndroidIncludeIcon = PackIconKind.Check;
            HasIos = true;
            IosIncludeIcon = PackIconKind.Check;
            HasUwp = false;
            UwpIncludeIcon = PackIconKind.Plus;

        }
    }
}
