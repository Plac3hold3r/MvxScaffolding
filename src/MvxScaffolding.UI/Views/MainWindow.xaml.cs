//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Core.ViewModels;
using MvxScaffolding.Core.ViewModels.Dialogs;
using MvxScaffolding.Core.ViewModels.Interfaces;
using MvxScaffolding.UI.Dialogs;

namespace MvxScaffolding.UI.Views
{
    public partial class MainWindow : MetroWindow, IClosable
    {
        public MainWindow()
        {
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

        void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is SimpleInfoViewModel infoViewModel
                && !string.IsNullOrWhiteSpace(infoViewModel.ReadMoreLink)
                && !string.IsNullOrWhiteSpace(infoViewModel.TemplateLink))
            {
                (DataContext as MainViewModel).OpenLink(infoViewModel.ReadMoreLink, infoViewModel.TemplateLink);
            }
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
