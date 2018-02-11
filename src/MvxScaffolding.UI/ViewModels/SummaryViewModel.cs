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
