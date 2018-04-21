//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MvxScaffolding.UI.Converters
{
    public class RequiredLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} *";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
