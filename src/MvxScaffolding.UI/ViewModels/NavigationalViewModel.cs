using MvxScaffolding.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.ViewModels
{
    public class NavigationalViewModel
    {
        public string SecondaryActionText { get; set; } = "PREVIOUS";
        public string PrimaryActionText { get; set; } = "NEXT";
        public IViewModel ViewModel { get; set; }
    }
}
