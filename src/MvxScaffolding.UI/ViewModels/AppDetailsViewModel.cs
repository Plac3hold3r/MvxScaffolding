//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Windows.Input;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.ViewModels.Dialogs;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel, IValidationViewModel
    {
        public ICommand GoToGitHubCommand { get; }

        public AppDetailsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
        }

        public WizardOptionViewModel Options { get; private set; }

        private SimpleInfoViewModel _editorConfigInfoModel;
        public SimpleInfoViewModel EditorConfigInfoModel
            => _editorConfigInfoModel ?? (_editorConfigInfoModel = SimpleInfoViewModel.EditorConfigInfo());

        private void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        public bool Validate()
        {
            Options.ValidateModelProperty(Options.AppId, nameof(WizardOptionViewModel.AppId));
            Options.ValidateModelProperty(Options.AppName, nameof(WizardOptionViewModel.AppName));

            return !Options.HasErrors;
        }
    }
}
