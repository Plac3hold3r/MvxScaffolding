using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Properties;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MvxScaffolding.UI.ViewModels.Dialogs
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand GoToAuthorGitHubCommand { get; }

        public AboutViewModel()
        {
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            GoToAuthorGitHubCommand = new RelayCommand(GoToAuthorGitHubLink);
        }

        private void GoToGitHubLink()
        {
            Process.Start(Settings.Default.GitHubUri);
        }

        private void GoToAuthorGitHubLink()
        {
            Process.Start(Settings.Default.AuthorGitHubUri);
        }
    }
}
