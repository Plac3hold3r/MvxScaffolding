using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Configuration;
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
            Process.Start(Config.Current.GitHubUri);
        }

        private void GoToAuthorGitHubLink()
        {
            Process.Start(Config.Current.AuthorGitHubUri);
        }
    }
}
