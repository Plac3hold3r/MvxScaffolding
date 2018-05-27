//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;

namespace MvxScaffolding.UI.Converters
{
    public class SelectedPlatformTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isSelected)
            {
                if (isSelected)
                {
                    return PackIconKind.Check;
                }
                else
                {
                    return PackIconKind.Plus;
                }
            }

            throw new ArgumentException($"Invalid type for {nameof(SelectedPlatformTypeToIconConverter)}", nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
