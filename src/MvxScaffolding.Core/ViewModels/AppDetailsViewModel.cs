//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Helpers;
using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.Core.ViewModels
{
    public class AppDetailsViewModel : BaseViewModel, IValidationViewModel
    {
        public ICommand GoToGitHubCommand { get; }

        public AppDetailsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);

            ScaffoldTemplateOptions = Config.Current.PlatformScaffoldTypeConfiguration.ToScaffoldTemplateOptions(MvxScaffoldingContext.CurrentTemplateType, options);
            Options.SelectedScaffoldType = ScaffoldTemplateOptions.First();
            Options.SelectedScaffoldType.IsSelected = true;
        }

        public string ProjectName => MvxScaffoldingContext.SafeProjectName;

        public WizardOptionViewModel Options { get; }

        public List<ScaffoldTemplateOptionViewModel> ScaffoldTemplateOptions { get; private set; }

        SimpleInfoViewModel _editorConfigInfoModel;

        public SimpleInfoViewModel EditorConfigInfoModel
            => _editorConfigInfoModel ?? (_editorConfigInfoModel = SimpleInfoViewModel.EditorConfigInfo());

        void GoToGitHubLink()
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
