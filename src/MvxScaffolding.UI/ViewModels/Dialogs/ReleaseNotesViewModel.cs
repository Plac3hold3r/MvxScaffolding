//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.IO;

namespace MvxScaffolding.UI.ViewModels.Dialogs
{
    public class ReleaseNotesViewModel : AboutViewModel
    {
        private string _releaseNotes;

        public string ReleaseNotes
        {
            get => _releaseNotes;
            set { _releaseNotes = value; OnPropertyChanged(nameof(ReleaseNotes)); }
        }

        public override void OnDialogOpened()
        {
            ReleaseNotes = File.ReadAllText("Resources/CHANGELOG.md");
        }
    }
}
