//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.IO;
using System.Reflection;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.ViewModels.Dialogs
{
    public class ReleaseNotesViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand GoToChangelogCommand { get; }

        private string _releaseNotes;

        public string ReleaseNotes
        {
            get => _releaseNotes;
            set => SetProperty(ref _releaseNotes, value);
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
            var asmLocation = Assembly.GetExecutingAssembly().Location;
            var extensionDirectory = Path.GetDirectoryName(asmLocation);
            var releaseNoteLocation = Path.Combine(extensionDirectory, "Resources/release_notes.md");
            ReleaseNotes = File.ReadAllText(releaseNoteLocation);
        }
    }
}
