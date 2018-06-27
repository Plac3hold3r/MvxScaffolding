//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MvxScaffolding.Core.Dialogs.Interfaces;
using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.UI.Dialogs
{
    public class DialohHost : DialogHost, IDialogHost
    {
        void IDialogHost.Show(IViewModel viewModel)
        {
            Show(viewModel, OnDialogOpened);
        }

        void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
        {
            if (eventArgs.Session.Content is IViewModel viewModel)
                viewModel.OnDialogOpened();
        }
    }
}
