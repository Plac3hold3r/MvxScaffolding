using MaterialDesignThemes.Wpf;
using MvxScaffolding.UI.Commands;
using MvxScaffolding.UI.Configuration;
using MvxScaffolding.UI.Contexts;
using MvxScaffolding.UI.Diagnostics;
using MvxScaffolding.UI.Template;
using MvxScaffolding.UI.ViewModels.Dialogs;
using MvxScaffolding.UI.ViewModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

        public ICommand ShowDialogCommand { get; }

        protected BaseViewModel()
        {
            ShowDialogCommand = new RelayCommand<IViewModel>(ShowDialog);
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
