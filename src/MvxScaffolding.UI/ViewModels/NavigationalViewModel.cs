using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.ViewModels
{
    public class NavigationalViewModel
    {
        public string SecondaryActionText { get; set; } = "PREVIOUS";
        public string PrimaryActionText { get; set; } = "NEXT";
        public IViewModel ViewModel { get; set; }
    }
}
