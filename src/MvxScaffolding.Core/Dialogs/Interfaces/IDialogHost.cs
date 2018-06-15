//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.Core.Dialogs.Interfaces
{
    public interface IDialogHost
    {
        void Show(IViewModel viewModel);
    }
}
