using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvxNative.Core.ViewModels.Menu;
using MvxNative.Core.ViewModels.Settings;

namespace MvxNative.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
    {
        public IMvxAsyncCommand ShowMenuCommand { get; private set; }

        public MainContainerViewModel()
        {
            ShowMenuCommand = new MvxAsyncCommand(NavigateToMenuAsync);
        }

        private Task NavigateToMenuAsync()
        {
            return NavigationService.Navigate<MenuViewModel>();
        }
    }
}
