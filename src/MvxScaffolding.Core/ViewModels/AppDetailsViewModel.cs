//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.Core.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel, IValidationViewModel
    {
        public ICommand GoToGitHubCommand { get; }
        public ICommand SelectScaffoldTypeCommand { get; }

        public AppDetailsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            SelectScaffoldTypeCommand = new RelayCommand<ScaffoldType>(SelectScaffoldType);
        }

        public string ProjectName => MvxScaffoldingContext.SafeProjectName;

        public WizardOptionViewModel Options { get; private set; }

        SimpleInfoViewModel _editorConfigInfoModel;

        public SimpleInfoViewModel EditorConfigInfoModel
            => _editorConfigInfoModel ?? (_editorConfigInfoModel = SimpleInfoViewModel.EditorConfigInfo());

        void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }

        void SelectScaffoldType(ScaffoldType scaffoldType)
        {
            Options.SelectedScaffoldType = scaffoldType;
        }

        public bool Validate()
        {
            Options.ValidateModelProperty(Options.AppId, nameof(WizardOptionViewModel.AppId));
            Options.ValidateModelProperty(Options.AppName, nameof(WizardOptionViewModel.AppName));

            return !Options.HasErrors;
        }
    }
}
