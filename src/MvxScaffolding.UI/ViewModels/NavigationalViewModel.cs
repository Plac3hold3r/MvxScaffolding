using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.ViewModels
{
    public class NavigationalViewModel
    {
        public string SecondaryActionText { get; set; } = "Previous";
        public string PrimaryActionText { get; set; } = "Next";
        public IViewModel ViewModel { get; set; }
    }
}
