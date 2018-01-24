using System.Windows;
using System.Windows.Media;

namespace MvxScaffolding.UI.Styles
{
    public static class MvxScaffoldingColorResource
    {
        public static SolidColorBrush PrimaryBrush => GetColourFromResources("PrimaryColorBrush");
        public static SolidColorBrush AccentBrush => GetColourFromResources("AccentHueColorBrush");

        public static SolidColorBrush MaterialDesignBodyLightBrush => GetColourFromResources("MaterialDesignBodyLight");
        public static SolidColorBrush MaterialDesignBodyBrush => GetColourFromResources("MaterialDesignBody");

        public static SolidColorBrush GetColourFromResources(string resource)
            => Application.Current.MainWindow.Resources[resource] as SolidColorBrush;
    }
}
