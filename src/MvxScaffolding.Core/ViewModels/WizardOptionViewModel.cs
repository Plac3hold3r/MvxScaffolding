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
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.Validation;
using MvxScaffolding.Core.ViewModels.Helpers;
using MvxScaffolding.Localization.Resources;

namespace MvxScaffolding.Core.ViewModels
{
    public class WizardOptionViewModel : BaseViewModel, ITemplateOptions, INotifyDataErrorInfo
    {
        readonly Dictionary<string, ICollection<string>>
            _validationErrors = new Dictionary<string, ICollection<string>>();

        string _appName = MvxScaffoldingContext.ProjectName;
        [Required(ErrorMessageResourceName = nameof(LocalResources.AppDetails_Validation_Display_Name), ErrorMessageResourceType = typeof(LocalResources))]
        public string AppName
        {
            get => _appName;
            set
            {
                SetProperty(ref _appName, value);
                ValidateModelProperty(value, nameof(AppName));
            }
        }

        string _appId = $"com.{ MvxScaffoldingContext.SafeProjectName.ToLower() }";
        [Required(ErrorMessageResourceName = nameof(LocalResources.AppDetails_Validation_Identifier), ErrorMessageResourceType = typeof(LocalResources))]
        public string AppId
        {
            get => _appId;
            set
            {
                SetProperty(ref _appId, value);
                ValidateModelProperty(value, nameof(AppId));
            }
        }

        string _solutionName = MvxScaffoldingContext.SolutionName;
        [Required(ErrorMessageResourceName = nameof(LocalResources.AppDetails_Validation_SolutionName), ErrorMessageResourceType = typeof(LocalResources))]
        public string SolutionName
        {
            get => _solutionName;
            set
            {
                SetProperty(ref _solutionName, value);
                ValidateModelProperty(value, nameof(SolutionName));
            }
        }

        bool _hasEditorConfig;

        public bool HasEditorConfig
        {
            get => _hasEditorConfig;
            set => SetProperty(ref _hasEditorConfig, value);
        }

        ScaffoldTemplateOptionViewModel _selectedScaffoldType;

        public ScaffoldTemplateOptionViewModel SelectedScaffoldType
        {
            get => _selectedScaffoldType;
            set
            {
                if (SetProperty(ref _selectedScaffoldType, value))
                    ResetPlatformOptions();
            }
        }

        string _selectedProjectGrouping;

        public string SelectedProjectGrouping
        {
            get => _selectedProjectGrouping;
            set => SetProperty(ref _selectedProjectGrouping, value);
        }

        public Dictionary<string, string> ProjectGroupingOptions { get; }

        string _selectedNetStandard;

        public string SelectedNetStandard
        {
            get => _selectedNetStandard;
            set => SetProperty(ref _selectedNetStandard, value);
        }

        public Dictionary<string, string> NetStandardOptions { get; private set; }

        bool _hasCoreUnitTestProject;

        public bool HasCoreUnitTestProject
        {
            get => _hasCoreUnitTestProject;
            set => SetProperty(ref _hasCoreUnitTestProject, value);
        }

        string _selectedMinAndroidSDK;

        public string SelectedMinAndroidSDK
        {
            get => _selectedMinAndroidSDK;
            set => SetProperty(ref _selectedMinAndroidSDK, value);
        }

        Dictionary<string, string> _minAndroidSDKOptions;

        public Dictionary<string, string> MinAndroidSDKOptions
        {
            get => _minAndroidSDKOptions;
            private set => SetProperty(ref _minAndroidSDKOptions, value);
        }

        bool _hasAndroidUnitTestProject;

        public bool HasAndroidUnitTestProject
        {
            get => _hasAndroidUnitTestProject;
            set => SetProperty(ref _hasAndroidUnitTestProject, value);
        }

        bool _hasAndroidUiTestProject;

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

        string _selectedAndroidLayoutType;

        public string SelectedAndroidLayoutType
        {
            get => _selectedAndroidLayoutType;
            set => SetProperty(ref _selectedAndroidLayoutType, value);
        }

        Dictionary<string, string> _androidLayoutTypes;

        public Dictionary<string, string> AndroidLayoutTypes
        {
            get => _androidLayoutTypes;
            private set => SetProperty(ref _androidLayoutTypes, value);
        }

        string _selectedMinIosSDK;

        public string SelectedMinIosSDK
        {
            get => _selectedMinIosSDK;
            set => SetProperty(ref _selectedMinIosSDK, value);
        }

        Dictionary<string, string> _minIosSDKOptions;

        public Dictionary<string, string> MinIosSDKOptions
        {
            get => _minIosSDKOptions;
            private set => SetProperty(ref _minIosSDKOptions, value);
        }

        bool _hasIosUnitTestProject;

        public bool HasIosUnitTestProject
        {
            get => _hasIosUnitTestProject;
            set => SetProperty(ref _hasIosUnitTestProject, value);
        }

        bool _hasIosUiTestProject;

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

        string _selectedIosLayoutType;

        public string SelectedIosLayoutType
        {
            get => _selectedIosLayoutType;
            set => SetProperty(ref _selectedIosLayoutType, value);
        }

        Dictionary<string, string> _iosLayoutTypes;

        public Dictionary<string, string> IosLayoutTypes
        {
            get => _iosLayoutTypes;
            private set => SetProperty(ref _iosLayoutTypes, value);
        }

        string _uwpDescription;
        [RequiredIf(nameof(HasUwp), true, ErrorMessageResourceName = nameof(LocalResources.PlatformOptions_Validation_Uwp_Description), ErrorMessageResourceType = typeof(LocalResources))]
        public string UwpDescription
        {
            get => _uwpDescription;
            set
            {
                SetProperty(ref _uwpDescription, value);
                ValidateModelProperty(value, nameof(UwpDescription));
            }
        }

        string _selectedMinUwpSDK;

        public string SelectedMinUwpSDK
        {
            get => _selectedMinUwpSDK;
            set => SetProperty(ref _selectedMinUwpSDK, value);
        }

        Dictionary<string, string> _minUwpSDKOptions;

        public Dictionary<string, string> MinUwpSDKOptions
        {
            get => _minUwpSDKOptions;
            private set => SetProperty(ref _minUwpSDKOptions, value);
        }

        bool _hasUwpUnitTestProject;

        public bool HasUwpUnitTestProject
        {
            get => _hasUwpUnitTestProject;
            set => SetProperty(ref _hasUwpUnitTestProject, value);
        }

        bool _hasUwpUiTestProject;

        public bool HasUwpUiTestProject
        {
            get => _hasUwpUiTestProject;
            set => SetProperty(ref _hasUwpUiTestProject, value);
        }

        bool _hasAndroid;

        public bool HasAndroid
        {
            get => _hasAndroid;
            set => SetProperty(ref _hasAndroid, value);
        }

        bool _hasIos;

        public bool HasIos
        {
            get => _hasIos;
            set => SetProperty(ref _hasIos, value);
        }

        bool _hasUwp;

        public bool HasUwp
        {
            get => _hasUwp;
            set
            {
                SetProperty(ref _hasUwp, value);
                if (!value)
                    ValidateModelProperty(value, nameof(UwpDescription));
            }
        }

        bool _hasAndroidSupport;

        public bool HasAndroidSupport
        {
            get => _hasAndroidSupport;
            set => SetProperty(ref _hasAndroidSupport, value);
        }

        bool _hasIosSupport;

        public bool HasIosSupport
        {
            get => _hasIosSupport;
            set => SetProperty(ref _hasIosSupport, value);
        }

        bool _hasUwpSupport;

        public bool HasUwpSupport
        {
            get => _hasUwpSupport;
            set => SetProperty(ref _hasUwpSupport, value);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        void RaiseErrorsChanged(string propertyName)
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
            ProjectGroupingOptions = TemplateConfig.ProjectGroupingOptions;
            SelectedProjectGrouping = TemplateConfig.ProjectGroupingOptionDefault;

            HasEditorConfig = true;
        }

        private void ResetPlatformOptions()
        {
            NetStandardOptions = TemplateConfig.NetStandardOptions.Filter(SelectedScaffoldType.Exclude);
            SelectedNetStandard = TemplateConfig.NetStandardOptionDefault;

            HasCoreUnitTestProject = false;

            MinAndroidSDKOptions = TemplateConfig.MinAndroidSDKOptions.Filter(SelectedScaffoldType.Exclude);
            SelectedMinAndroidSDK = TemplateConfig.MinAndroidSDKOptionDefault;

            HasAndroidUnitTestProject = false;
            HasAndroidUiTestProject = false;

            AndroidLayoutTypes = TemplateConfig.AndroidLayoutTypes.Filter(SelectedScaffoldType.Exclude);
            SelectedAndroidLayoutType = TemplateConfig.AndroidLayoutTypeDefault;

            MinIosSDKOptions = TemplateConfig.MinIosSDKOptions.Filter(SelectedScaffoldType.Exclude);
            SelectedMinIosSDK = TemplateConfig.MinIosSDKOptionDefault;

            HasIosUnitTestProject = false;
            HasIosUiTestProject = false;

            IosLayoutTypes = TemplateConfig.IosLayoutTypes.Filter(SelectedScaffoldType.Exclude);
            SelectedIosLayoutType = TemplateConfig.IosLayoutTypeDefault;

            MinUwpSDKOptions = TemplateConfig.MinUwpSDKOptions.Filter(SelectedScaffoldType.Exclude);
            SelectedMinUwpSDK = TemplateConfig.MinUwpSDKOptionDefault;

            HasUwpUnitTestProject = false;
            HasUwpUiTestProject = false;

            HasAndroid = true;
            HasIos = true;
            HasUwp = false;

            HasAndroidSupport = SelectedScaffoldType.HasAndroidSupport;
            HasIosSupport = SelectedScaffoldType.HasIosSupport;
            HasUwpSupport = SelectedScaffoldType.HasUwpSupport;
        }
    }
}
