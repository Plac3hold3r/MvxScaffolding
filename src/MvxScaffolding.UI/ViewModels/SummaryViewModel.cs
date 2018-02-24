//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

namespace MvxScaffolding.UI.ViewModels
{
    public class SummaryViewModel : BaseViewModel
    {
        public SummaryViewModel(WizardOptionViewModel options)
        {
            Options = options;
        }

        public WizardOptionViewModel Options { get; private set; }
    }
}
