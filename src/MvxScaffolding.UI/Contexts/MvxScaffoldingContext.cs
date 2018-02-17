//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.UI.Template;
using MvxScaffolding.UI.ViewModels;

namespace MvxScaffolding.UI.Contexts
{
    public static class MvxScaffoldingContext
    {
        public static TemplateType CurrentTemplateType { get; set; }

        public static WizardOptionViewModel UserSelectedOptions { get; set; }
    }
}
