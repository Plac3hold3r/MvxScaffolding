using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.UI.Contexts;
using MvxScaffolding.UI.Template;
using MvxScaffolding.UI.ViewModels;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.Views
{
    public partial class MainWindow : MetroWindow, IClosable
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            Brush themeBrush = MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative
                ? (Brush)FindResource("PrimaryColorBrush")
                : (Brush)FindResource("AccentHueColorBrush");

            WindowTitleBrush = themeBrush;
            GlowBrush = themeBrush;
        }

        private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is string stringParameter && !string.IsNullOrWhiteSpace(stringParameter))
            {
                // TODO [JF] :: add url open tracking
                Process.Start(stringParameter);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
