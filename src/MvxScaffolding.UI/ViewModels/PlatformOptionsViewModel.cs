using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.UI.Commands;

namespace MvxScaffolding.UI.ViewModels
{
    public class PlatformOptionsViewModel : IViewModel
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
    }
}
