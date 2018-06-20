using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvxNative.Core.ViewModels.Main;
using MvxNative.Core.ViewModels.Settings;

namespace MvxNative.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        public IMvxAsyncCommand ShowHomeCommand { get; private set; }
        public IMvxAsyncCommand ShowSettingsCommand { get; private set; }

        public MenuViewModel()
        {
            ShowHomeCommand = new MvxAsyncCommand(NavigateToHomeAsync);
            ShowSettingsCommand = new MvxAsyncCommand(NavigateToSettingsAsync);
        }

        private Task NavigateToHomeAsync()
        {
            return NavigationService.Navigate<MainViewModel>();
        }

        private Task NavigateToSettingsAsync()
        {
            return NavigationService.Navigate<SettingsViewModel>();
        }
    }
}
