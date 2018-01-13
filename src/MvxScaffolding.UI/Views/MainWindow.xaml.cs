using System;

using System.Windows;
using MahApps.Metro.Controls;
using MvxScaffolding.UI.Helpers;

namespace MvxScaffolding.UI.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            var colorsXamlLocation = MvxScaffoldingContext.TemplateType == TemplateType.MvxNative
                ? Constants.MvxNativeColorsUri
                : Constants.MvxFormsColorsUri;

            var colors = new Uri(colorsXamlLocation, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = colors });

            InitializeComponent();
        }
    }
}
