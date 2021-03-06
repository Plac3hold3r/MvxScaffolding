//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Files;
using MvxScaffolding.Core.Tasks;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Interfaces;
using MvxScaffolding.UI.Dialogs;
using MvxScaffolding.UI.Utils;

namespace MvxScaffolding.UI.Views
{
    public partial class MainWindow : MetroWindow, IClosable
    {
        public MainWindow()
        {
            Application.Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(HandlerDispatcherUnhandledExceptionEvent);

            InitializeComponent();

            MvxScaffoldingContext.DialogHost = new DialohHost();

            DataContext = new MainViewModel();

            Brush themeBrush = MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative
                ? (Brush)FindResource("PrimaryColorBrush")
                : (Brush)FindResource("AccentHueColorBrush");

            WindowTitleBrush = themeBrush;
            GlowBrush = themeBrush;
#if DEBUG
            ShowInTaskbar = true;
#endif
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (MvxScaffoldingContext.RemoveOldSolutionDirectoryStatus == FileDeleteStatus.UnauthorizedAccessError
                && DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.ShowDialogCommand.Execute(SimpleInfoViewModel.UnauthorizedAccessErrorInfo());
            }
        }

        private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is SimpleInfoViewModel infoViewModel
                && !string.IsNullOrWhiteSpace(infoViewModel.ReadMoreLink)
                && !string.IsNullOrWhiteSpace(infoViewModel.TemplateLink))
            {
                (DataContext as MainViewModel).OpenLink(infoViewModel.ReadMoreLink, infoViewModel.TemplateLink);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void HandlerDispatcherUnhandledExceptionEvent(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Current.Exception.TrackAsync(e.Exception, "Dispatcher unhandled exception running wizard")
                        .FireAndForget();

            ExceptionHandler.ShowErrorDialog(e.Exception);
        }
    }
}
