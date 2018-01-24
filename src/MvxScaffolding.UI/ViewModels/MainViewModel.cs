using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Helpers;

namespace MvxScaffolding.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly List<NavigationalViewModel> _navigationalViewModels;

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

        public MainViewModel()
        {
            ForwardCommand = new RelayCommand(NavigateForward);
            BackCommand = new RelayCommand(NavigateBackward);
            GoToGitHubCommand = new RelayCommand(GoToGitHubLink);

            var options = new WizardOptionViewModel();

            _navigationalViewModels = new List<NavigationalViewModel>
            {
                new NavigationalViewModel { SecondaryActionText = string.Empty, ViewModel = new AppDetailsViewModel(options) },
                new NavigationalViewModel { ViewModel = new PlatformOptionsViewModel(options) },
                new NavigationalViewModel { PrimaryActionText = "Done", ViewModel = new SummaryViewModel(options) }
            };

            NavigateFirst();
        }

        private void NavigateFirst()
        {
            SelectedNavigationalItem = _navigationalViewModels.First();
        }

        private void NavigateForward()
        {
            if (SelectedViewModelIndex + 1 < _navigationalViewModels.Count)
                SelectedNavigationalItem = _navigationalViewModels[++SelectedViewModelIndex];
        }

        private void NavigateBackward()
        {
            if (SelectedViewModelIndex - 1 >= 0)
                SelectedNavigationalItem = _navigationalViewModels[--SelectedViewModelIndex];
        }

        private void GoToGitHubLink()
        {
            Process.Start("https://github.com/Plac3hold3r/MvxScaffolding");
        }
    }
}
