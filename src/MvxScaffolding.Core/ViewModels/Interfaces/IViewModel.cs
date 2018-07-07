//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace MvxScaffolding.Core.ViewModels.Interfaces
{
    public interface IViewModel
    {
        Task OnDialogOpenedAsync();
    }
}
