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
using MvxScaffolding.UI.Properties;

namespace MvxScaffolding.UI.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }

        public ICommand GoToGitHubPrivacyPolicyCommand { get; }

        public AppDetailsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            GoToGitHubPrivacyPolicyCommand = new RelayCommand(GoToGitHubPrivacyPolicy);
        }

        public WizardOptionViewModel Options { get; private set; }

        private void GoToGitHubPrivacyPolicy()
        {
            // TODO [JF] :: get the correct policy Uri
            Process.Start(Settings.Default.PrivacyPolicyUri);
        }

        private void GoToGitHubLink()
        {
            Process.Start(Settings.Default.GitHubUri);
        }
    }
}
