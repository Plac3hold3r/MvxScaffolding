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
            ProjectGroupingOptions = new Dictionary<string, string>
            {
                ["flat"] = "Flat",
                ["test-group"] = "Test Group",
                ["platform"] = "Platform"
            };
            SelectedProjectGrouping = "flat";

            HasEditorConfig = true;

            NetStandardOptions = new Dictionary<string, string>
            {
                ["2.0"] = ".NET Standard 2.0",
                ["1.6"] = ".NET Standard 1.6",
                ["1.5"] = ".NET Standard 1.5",
                ["1.4"] = ".NET Standard 1.4",
                ["1.3"] = ".NET Standard 1.3",
                ["1.2"] = ".NET Standard 1.2",
                ["1.1"] = ".NET Standard 1.1",
                ["1.0"] = ".NET Standard 1.0"
            };
            SelectedNetStandard = "2.0";

            HasCoreUnitTestProject = false;

            MinAndroidSDKOptions = new Dictionary<string, string>
            {
                ["26"] = "Android 8 - Oreo v26",
                ["25"] = "Android 7.1 - Nougat v25",
                ["24"] = "Android 7 - Nougat v24",
                ["23"] = "Android 6 - Marshmallow v23",
                ["22"] = "Android 5.1 - Lollipop v22",
                ["21"] = "Android 5 - Lollipop v21",
                ["19"] = "Android 4 - KitKat v19",
                ["18"] = "Android 4.3 - Jelly Bean v18",
                ["17"] = "Android 4.2 - Jelly Bean v17",
                ["16"] = "Android 4.1 - Jelly Bean v16",
                ["15"] = "Android 4.0.3 - Ice Cream Sandwich v15",
                ["14"] = "Android 4 - Ice Cream Sandwich v14",
            };
            SelectedMinAndroidSDK = "19";

            HasAndroidUnitTestProject = false;
            HasAndroidUiTestProject = false;
            HasAndroidXml = false;

            MinIosSDKOptions = new Dictionary<string, string>
            {
                ["11.2"] = "iOS 11.2",
                ["11.1"] = "iOS 11.1",
                ["11.0"] = "iOS 11",
                ["10.3"] = "iOS 10.3",
                ["10.2"] = "iOS 10.2",
                ["10.1"] = "iOS 10.1",
                ["10.0"] = "iOS 10",
                ["9.3"] = "iOS 9.3",
                ["9.2"] = "iOS 9.2",
                ["9.1"] = "iOS 9.1",
                ["9.0"] = "iOS 9.0",
            };
            SelectedMinIosSDK = "10.0";

            HasIosUnitTestProject = false;
            HasIosUiTestProject = false;
            HasIosFluentLayout = false;
            HasIosHyperion = false;

            MinUwpSDKOptions = new Dictionary<string, string>
            {
                ["16299"] = "1709 - Fall Creators Update",
                ["15063"] = "1703 - Creators Update",
                ["14393"] = "1607 - Anniversary Update",
                ["10586"] = "1511 - November Update",
                ["10240"] = "1507 - RTM",
            };
            SelectedMinUwpSDK = "16299";

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
