//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.Localization.Resources;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class NavigationalViewModel
    {
        public string SecondaryActionText { get; set; } = LocalResources.Main_Window_Button_Previous;
        public string PrimaryActionText { get; set; } = LocalResources.Main_Window_Button_Next;
        public IViewModel ViewModel { get; set; }
    }
}
