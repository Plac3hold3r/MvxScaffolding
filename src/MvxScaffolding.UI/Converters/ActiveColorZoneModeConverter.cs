using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;

namespace MvxScaffolding.UI.Converters
{
    public class ActiveColorZoneModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valueBool)
                return valueBool ? ColorZoneMode.PrimaryMid : ColorZoneMode.Accent;

            return ColorZoneMode.PrimaryMid;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
