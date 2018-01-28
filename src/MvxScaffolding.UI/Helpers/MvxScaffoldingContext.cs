using MvxScaffolding.UI.ViewModels;

namespace MvxScaffolding.UI.Helpers
{
    public static class MvxScaffoldingContext
    {
        public static TemplateType CurrentTemplateType { get; set; } = TemplateType.MvxForms;
        public static WizardOptionViewModel UserSelectedOptions { get; set; }
    }
}
