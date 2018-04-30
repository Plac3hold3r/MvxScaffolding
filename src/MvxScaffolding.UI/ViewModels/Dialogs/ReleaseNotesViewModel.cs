//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.IO;
using System.Windows.Input;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;
using MvxScaffolding.UI.Commands;

namespace MvxScaffolding.UI.ViewModels.Dialogs
{
    public class ReleaseNotesViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand GoToChangelogCommand { get; }

        private string _releaseNotes;

        public string ReleaseNotes
        {
            get => _releaseNotes;
            set { _releaseNotes = value; OnPropertyChanged(nameof(ReleaseNotes)); }
        }

        public ReleaseNotesViewModel()
        {
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            GoToChangelogCommand = new RelayCommand(GoToChangelogLink);
        }

        private void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        private void GoToChangelogLink()
        {
            OpenLink(Config.Current.ChangelogUri, TemplateLinks.Changelog);
        }

        public override void OnDialogOpened()
        {
            ReleaseNotes = File.ReadAllText("Resources/release_notes.md");
        }
    }
}
