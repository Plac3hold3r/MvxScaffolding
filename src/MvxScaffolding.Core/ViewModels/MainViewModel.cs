//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Tasks;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Interfaces;
using MvxScaffolding.Localization.Resources;

namespace MvxScaffolding.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly List<NavigationalViewModel> _navigationalViewModels;
        readonly WizardOptionViewModel _options;

        public ICommand ForwardCommand { get; }

        public ICommand BackCommand { get; }

        public ICommand GoToGitHubCommand { get; }

        public ICommand ShowReleaseNotesCommand { get; }

        public ICommand DismissNotificationCommand { get; }

        int _selectedViewModelIndex;

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set => SetProperty(ref _selectedViewModelIndex, value);
        }

        NavigationalViewModel _selectedNavigationalItem;

        public NavigationalViewModel SelectedNavigationalItem
        {
            get => _selectedNavigationalItem;
            set
            {
                if (SetProperty(ref _selectedNavigationalItem, value))
                {
                    Logger.Current.Telemetry.TrackWizardPageAsync(SelectedNavigationalItem.ViewModel.GetType().Name)
                        .FireAndForget();
                }
            }
        }

        SimpleInfoViewModel _privacyInfoModel;
        public SimpleInfoViewModel PrivacyInfoModel
            => _privacyInfoModel ?? (_privacyInfoModel = SimpleInfoViewModel.PrivacyInfo());

        SimpleInfoViewModel _translateInfoModel;
        public SimpleInfoViewModel TranslateInfoModel
            => _translateInfoModel ?? (_translateInfoModel = SimpleInfoViewModel.TranslateInfo());

        bool _hasUpdatedNotification;

        public bool HasUpdatedNotification
        {
            get => _hasUpdatedNotification;
            set => SetProperty(ref _hasUpdatedNotification, value);
        }

        public MainViewModel()
        {
            MvxScaffoldingContext.RunningTimer = Stopwatch.StartNew();

            ForwardCommand = new RelayCommand<IClosable>(NavigateForward);
            BackCommand = new RelayCommand(NavigateBackward);
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);
            ShowReleaseNotesCommand = new RelayCommand(NavigateToReleaseNotes);
            DismissNotificationCommand = new RelayCommand(DismissNotification);

            _options = new WizardOptionViewModel();

            _navigationalViewModels = new List<NavigationalViewModel>
            {
                new NavigationalViewModel { SecondaryActionText = string.Empty, ViewModel = new AppDetailsViewModel(_options) },
                new NavigationalViewModel { ViewModel = new PlatformOptionsViewModel(_options) },
                new NavigationalViewModel { PrimaryActionText = LocalResources.Main_Window_Button_Done, ViewModel = new SummaryViewModel(_options) }
            };

            NavigateFirst();

            ShowUpdatedNotification();
        }

        void ShowUpdatedNotification()
        {
            if (MvxScaffoldingContext.LastKnownVersion == null || MvxScaffoldingContext.LastKnownVersion < MvxScaffoldingContext.WizardVersion)
            {
                MvxScaffoldingContext.LastKnownVersion = MvxScaffoldingContext.WizardVersion;
                HasUpdatedNotification = true;
            }
        }

        void NavigateFirst()
        {
            SelectedNavigationalItem = _navigationalViewModels.First();
        }

        void NavigateForward(IClosable window)
        {
            if (SelectedViewModelIndex + 1 < _navigationalViewModels.Count)
            {
                var validationViewModel = _navigationalViewModels[SelectedViewModelIndex].ViewModel as IValidationViewModel;

                if (validationViewModel is null || validationViewModel.Validate())
                {
                    SelectedNavigationalItem = _navigationalViewModels[++SelectedViewModelIndex];
                }

                if (HasUpdatedNotification)
                {
                    DismissNotification();
                }
            }
            else
            {
                MvxScaffoldingContext.UserSelectedOptions = _options;

                window.Close();
            }
        }

        void NavigateBackward()
        {
            if (SelectedViewModelIndex - 1 >= 0)
                SelectedNavigationalItem = _navigationalViewModels[--SelectedViewModelIndex];
        }

        void NavigateToReleaseNotes()
        {
            HasUpdatedNotification = false;
            ShowDialogCommand.Execute(new ReleaseNotesViewModel());

            Logger.Current.Telemetry.TrackUpdateVersionAsync(true)
                .FireAndForget();
        }

        void DismissNotification()
        {
            HasUpdatedNotification = false;

            Logger.Current.Telemetry.TrackUpdateVersionAsync(false)
                .FireAndForget();
        }

        void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }
    }
}
