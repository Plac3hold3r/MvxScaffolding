using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class PlatformOptionsViewModel : BaseViewModel, IValidationViewModel
    {
        public PlatformOptionsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            ToggleAndroidCommand = new RelayCommand(ToggleAndroid);
            ToggleIosCommand = new RelayCommand(ToggleIos);
            ToggleUwpCommand = new RelayCommand(ToggleUwp);
        }

        public WizardOptionViewModel Options { get; private set; }

        public ICommand ToggleAndroidCommand { get; }
        public ICommand ToggleIosCommand { get; }
        public ICommand ToggleUwpCommand { get; }

        private void ToggleAndroid()
        {
            Options.HasAndroid = !Options.HasAndroid;
            Options.AndroidIncludeIcon = Options.HasAndroid ? PackIconKind.Close : PackIconKind.Check;
        }

        private void ToggleIos()
        {
            Options.HasIos = !Options.HasIos;
            Options.IosIncludeIcon = Options.HasIos ? PackIconKind.Close : PackIconKind.Check;
        }

        private void ToggleUwp()
        {
            Options.HasUwp = !Options.HasUwp;
            Options.UwpIncludeIcon = Options.HasUwp ? PackIconKind.Close : PackIconKind.Check;
        }

        public bool Validate()
        {
            Options.ValidateModelProperty(Options.UwpDescription, nameof(WizardOptionViewModel.UwpDescription));

            return !Options.HasErrors;
        }
    }
}
