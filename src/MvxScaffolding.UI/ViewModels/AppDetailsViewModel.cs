using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Helpers;

namespace MvxScaffolding.UI.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }

        public ICommand GoToGitHubPrivacyPolicyCommand { get; }

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

            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            GoToGitHubPrivacyPolicyCommand = new RelayCommand(GoToGitHubPrivacyPolicy);

            AppVersion = "0.4.5";
            MvvmCrossVersion = "5.6.3";
        }

        public WizardOptionViewModel Options { get; private set; }

        private void GoToGitHubPrivacyPolicy()
        {
            // TODO [JF] :: get the correct policy Uri
            Process.Start("https://github.com/Plac3hold3r/MvxScaffolding");
        }

        private void GoToGitHubLink()
        {
            Process.Start("https://github.com/Plac3hold3r/MvxScaffolding");
        }
    }
}
