using MvxScaffolding.UI.Configuration;
using MvxScaffolding.UI.Helpers;
using MvxScaffolding.UI.ViewModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvxScaffolding.UI.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public bool IsNativeTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative;

        public bool IsFormsTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxForms;

        public string TemplateTypeName
            => IsNativeTemplate ? "MvxNative" : "MvxForms";

        public string AppVersion
            => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string TemplateVersion
            => Config.Current.TemplateVersion;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
