//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MvxScaffolding.Core.Commands;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Tasks;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Interfaces;

namespace MvxScaffolding.Core.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public bool IsNativeTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative;

        public bool IsFormsTemplate
           => MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxForms;

        public string TemplateTypeName
            => IsNativeTemplate ? "MvxNative" : "MvxForms";

        public Version WizardVersion
            => MvxScaffoldingContext.WizardVersion;

        public string WizardName
           => MvxScaffoldingContext.WizardName;

        public ICommand ShowDialogCommand { get; }

        protected BaseViewModel()
        {
            ShowDialogCommand = new RelayCommand<IViewModel>(ShowDialog);
        }

        public void OpenLink(string url, string linkName)
        {
            Logger.Current.Telemetry.TrackLinkOpenAsync(linkName)
                .FireAndForget();

            Process.Start(url);
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

        void ShowDialog(IViewModel viewModel)
        {
            string dialogPageName;

            if (viewModel is SimpleInfoViewModel infoViewModel)
                dialogPageName = $"{nameof(SimpleInfoViewModel)} - {infoViewModel.Title}";
            else
                dialogPageName = viewModel.GetType().Name;

            Logger.Current.Telemetry.TrackWizardPageAsync(dialogPageName)
                    .FireAndForget();

            MvxScaffoldingContext.DialogHost.Show(viewModel);
        }

        public virtual void OnDialogOpened()
        {
            // Method intentionally left empty.
        }
    }
}
