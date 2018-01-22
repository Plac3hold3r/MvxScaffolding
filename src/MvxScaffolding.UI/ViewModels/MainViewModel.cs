using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvxScaffolding.UI.Commands;

namespace MvxScaffolding.UI.ViewModels
{
    public class MainViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly List<IViewModel> _navigationalViewModels;

        public ICommand ForwardCommand { get; }

        public ICommand BackCommand { get; }

        private int _selectedViewModelIndex;

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set { _selectedViewModelIndex = value; OnPropertyChanged(nameof(SelectedViewModelIndex)); }
        }

        private IViewModel _selectedViewModel;

        public IViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        public MainViewModel()
        {
            ForwardCommand = new RelayCommand(NavigateForward);
            BackCommand = new RelayCommand(NavigateBackward);

            var options = new WizardOptionViewModel();

            _navigationalViewModels = new List<IViewModel>
            {
                new AppDetailsViewModel(options),
                new PlatformOptionsViewModel(options),
                new SummaryViewModel(options)
            };

            NavigateFirst();
        }

        private void NavigateFirst()
        {
            SelectedViewModel = _navigationalViewModels.First();
        }

        private void NavigateForward()
        {
            if (SelectedViewModelIndex + 1 < _navigationalViewModels.Count)
                SelectedViewModel = _navigationalViewModels[++SelectedViewModelIndex];
        }

        private void NavigateBackward()
        {
            if (SelectedViewModelIndex - 1 >= 0)
                SelectedViewModel = _navigationalViewModels[--SelectedViewModelIndex];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
