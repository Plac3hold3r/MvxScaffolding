using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvxScaffolding.UI.Helpers;

namespace MvxScaffolding.UI.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel
    {
        private string _appVersion;

        public string AppVersion
        {
            get => _appVersion;
            set { _appVersion = value; OnPropertyChanged(nameof(AppVersion)); }
        }

        private string _mvvmCrossVersion;

        public string MvvmCrossVersion
        {
            get => _mvvmCrossVersion;
            set { _mvvmCrossVersion = value; OnPropertyChanged(nameof(MvvmCrossVersion)); }
        }

        public bool IsNativeTemplate
            => MvxScaffoldingContext.TemplateType == TemplateType.MvxNative;

        public string TemplateTypeName
            => IsNativeTemplate ? "Native" : "Forms";

        public AppDetailsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            AppVersion = "0.4.5";
            MvvmCrossVersion = "5.6.3";
        }

        public WizardOptionViewModel Options { get; private set; }
    }
}
