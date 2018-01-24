using MvxScaffolding.UI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public bool IsNativeTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative;

        public string TemplateTypeName
            => IsNativeTemplate ? "Native" : "Forms";

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
