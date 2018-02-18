//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Tasks;
using MvxScaffolding.Core.Template;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.ViewModels.Dialogs;
using MvxScaffolding.UI.ViewModels.Interfaces;

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
            => MvxScaffoldingContext.WizardVersion;

        public string TemplateVersion
            => Config.Current.TemplateVersion;

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

        private void ShowDialog(IViewModel viewModel)
        {
            string dialogPageName;

            if (viewModel is SimpleInfoViewModel infoViewModel)
                dialogPageName = $"{nameof(SimpleInfoViewModel)} - {infoViewModel.Title}";
            else
                dialogPageName = viewModel.GetType().Name;

            Logger.Current.Telemetry.TrackWizardPageAsync(dialogPageName)
                    .FireAndForget();

            DialogHost.Show(viewModel);
        }
    }
}
