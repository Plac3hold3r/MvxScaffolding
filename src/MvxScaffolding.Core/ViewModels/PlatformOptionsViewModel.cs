//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.Core.ViewModels
{
    public class PlatformOptionsViewModel : BaseViewModel, IValidationViewModel
    {
        public PlatformOptionsViewModel(WizardOptionViewModel options)
        {
            Options = options;

            ToggleAndroidCommand = new RelayCommand(ToggleAndroid);
            ToggleIosCommand = new RelayCommand(ToggleIos);
            ToggleUwpCommand = new RelayCommand(ToggleUwp);

            ShowPlatformMarketShareCommand = new RelayCommand<PlatformType>(ShowPlatformMarketShare);
        }

        public WizardOptionViewModel Options { get; private set; }

        public ICommand ToggleAndroidCommand { get; }
        public ICommand ToggleIosCommand { get; }
        public ICommand ToggleUwpCommand { get; }
        public ICommand ShowPlatformMarketShareCommand { get; }

        void ToggleAndroid()
        {
            Options.HasAndroid = !Options.HasAndroid;
        }

        void ToggleIos()
        {
            Options.HasIos = !Options.HasIos;
        }

        void ToggleUwp()
        {
            Options.HasUwp = !Options.HasUwp;
        }

        void ShowPlatformMarketShare(PlatformType platform)
        {
            switch (platform)
            {
                case PlatformType.Android:
                    OpenLink(Config.Current.MarketShareAndroidUri, TemplateLinks.MarketShareAndroid);
                    break;
                case PlatformType.Ios:
                    OpenLink(Config.Current.MarketShareiOSUri, TemplateLinks.MarketShareIos);
                    break;
                case PlatformType.Uwp:
                    OpenLink(Config.Current.MarketShareWindowsUri, TemplateLinks.MarketShareWindows);
                    break;
            }
        }

        public bool Validate()
        {
            Options.ValidateModelProperty(Options.UwpDescription, nameof(WizardOptionViewModel.UwpDescription));

            return !Options.HasErrors;
        }
    }
}
