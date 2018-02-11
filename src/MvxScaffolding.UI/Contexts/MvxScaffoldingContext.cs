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
