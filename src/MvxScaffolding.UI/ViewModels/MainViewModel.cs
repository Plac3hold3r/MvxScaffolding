//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Configuration;
using MvxScaffolding.UI.Contexts;
using MvxScaffolding.UI.Diagnostics;
using MvxScaffolding.UI.Template;
using MvxScaffolding.UI.ViewModels.Dialogs;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly List<NavigationalViewModel> _navigationalViewModels;
        private readonly WizardOptionViewModel _options;
        private readonly Stopwatch _timer;

        public ICommand ForwardCommand { get; }

        public ICommand BackCommand { get; }

        public ICommand GoToGitHubCommand { get; }

        private int _selectedViewModelIndex;

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set { _selectedViewModelIndex = value; OnPropertyChanged(nameof(SelectedViewModelIndex)); }
        }

        private NavigationalViewModel _selectedNavigationalItem;

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

        private SimpleInfoViewModel _privacyInfoModel;
        public SimpleInfoViewModel PrivacyInfoModel
            => _privacyInfoModel ?? (_privacyInfoModel = SimpleInfoViewModel.PrivacyInfo());

        public MainViewModel()
        {
            _timer = Stopwatch.StartNew();

            ForwardCommand = new RelayCommand<IClosable>(NavigateForward);
            BackCommand = new RelayCommand(NavigateBackward);
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);

            _options = new WizardOptionViewModel();

            _navigationalViewModels = new List<NavigationalViewModel>
            {
                new NavigationalViewModel { SecondaryActionText = string.Empty, ViewModel = new AppDetailsViewModel(_options) },
                new NavigationalViewModel { ViewModel = new PlatformOptionsViewModel(_options) },
                new NavigationalViewModel { PrimaryActionText = "DONE", ViewModel = new SummaryViewModel(_options) }
            };

            NavigateFirst();
        }

        private void NavigateFirst()
        {
            SelectedNavigationalItem = _navigationalViewModels.First();
        }

        private void NavigateForward(IClosable window)
        {
            if (SelectedViewModelIndex + 1 < _navigationalViewModels.Count)
            {
                if (_navigationalViewModels[SelectedViewModelIndex].ViewModel is IValidationViewModel validationViewModel && !validationViewModel.Validate())
                    return;

                SelectedNavigationalItem = _navigationalViewModels[++SelectedViewModelIndex];
            }
            else
            {
                MvxScaffoldingContext.UserSelectedOptions = _options;
                _timer.Stop();

                Logger.Current.Telemetry.TrackProjectGenAsync(_options, _timer.Elapsed.TotalSeconds)
                    .FireAndForget();

                window.Close();
            }
        }

        private void NavigateBackward()
        {
            if (SelectedViewModelIndex - 1 >= 0)
                SelectedNavigationalItem = _navigationalViewModels[--SelectedViewModelIndex];
        }

        private void GoToGitHubLink()
        {
            OpenLink(Config.Current.GitHubUri, TemplateLinks.GitHub);
        }
    }
}
