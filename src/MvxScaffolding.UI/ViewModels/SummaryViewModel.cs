using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.ViewModels
{
    public class SummaryViewModel : IViewModel
    {
        public SummaryViewModel(WizardOptionViewModel options)
        {
            Options = options;
        }

        public WizardOptionViewModel Options { get; private set; }
    }
}
