﻿using MvxScaffolding.UI.Helpers;
using MvxScaffolding.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public bool IsNativeTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative;

        public bool IsFormsTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxForms;

        public string TemplateTypeName
            => IsNativeTemplate ? "Native" : "Forms";

        private string _appVersion;

        public string AppVersion
        {
            get => _appVersion;
            set { _appVersion = value; OnPropertyChanged(nameof(AppVersion)); }
        }

        protected BaseViewModel()
        {
            AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

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
