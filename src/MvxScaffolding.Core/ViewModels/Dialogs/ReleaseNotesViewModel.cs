//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Extensions;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.ViewModels.Dialogs
{
    public class ReleaseNotesViewModel : BaseViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand GoToChangelogCommand { get; }

        string _releaseNotes;

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

        void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        void GoToChangelogLink()
        {
            OpenLink(Config.Current.ChangelogUri, TemplateLinks.Changelog);
        }

        public override async Task OnDialogOpenedAsync()
        {
            using (var client = new WebClient())
                ReleaseNotes = await client.SafeDownloadStringTaskAsync(Config.Current.ReleaseNotesUri.AsRawUrl());
        }
    }
}
