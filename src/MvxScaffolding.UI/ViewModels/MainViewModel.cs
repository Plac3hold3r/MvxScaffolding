using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Helpers;
using MvxScaffolding.UI.Properties;
using MvxScaffolding.UI.ViewModels.Dialogs;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly List<NavigationalViewModel> _navigationalViewModels;
        private readonly WizardOptionViewModel _options;

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
            set { _selectedNavigationalItem = value; OnPropertyChanged(nameof(SelectedNavigationalItem)); }
        }

        private SimpleInfoViewModel _privacyInfoModel;
        public SimpleInfoViewModel PrivacyInfoModel
            => _privacyInfoModel ?? (_privacyInfoModel = SimpleInfoViewModel.PrivacyInfo());

        public MainViewModel()
        {
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
            Process.Start(Settings.Default.GitHubUri);
        }
    }
}
