using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Configuration;
using MvxScaffolding.UI.Template;
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
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        private void GoToAuthorGitHubLink()
        {
            OpenLink(Config.Current.AuthorGitHubUri, TemplateLinks.AuthorGitHub);
        }
    }
}
