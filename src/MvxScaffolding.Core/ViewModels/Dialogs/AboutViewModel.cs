//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.ViewModels.Dialogs
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand GoToAuthorGitHubCommand { get; }
        public ICommand GoToHelpTranslateCommand { get; }
        public ICommand GoToChangelogCommand { get; }
        public ICommand GoToPrivacyPolicyCommand { get; }

        public AboutViewModel()
        {
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            GoToAuthorGitHubCommand = new RelayCommand(GoToAuthorGitHubLink);
            GoToHelpTranslateCommand = new RelayCommand(GoToHelpTranslateLink);
            GoToChangelogCommand = new RelayCommand(GoToChangelogLink);
            GoToPrivacyPolicyCommand = new RelayCommand(GoToPrivacyPolicyLink);
        }

        void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        void GoToAuthorGitHubLink()
        {
            OpenLink(Config.Current.AuthorGitHubUri, TemplateLinks.AuthorGitHub);
        }

        void GoToHelpTranslateLink()
        {
            OpenLink(Config.Current.HelpTranslateUri, TemplateLinks.HelpTranslate);
        }

        void GoToChangelogLink()
        {
            OpenLink(Config.Current.ChangelogUri, TemplateLinks.Changelog);
        }

        void GoToPrivacyPolicyLink()
        {
            OpenLink(Config.Current.PrivacyPolicyUri, TemplateLinks.PrivacyPolicy);
        }
    }
}
