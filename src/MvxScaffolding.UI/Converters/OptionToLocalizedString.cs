//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace MvxScaffolding.UI.Converters
{
    public class OptionToLocalizedString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is string lookupKey
                && values[1] is Dictionary<string, string> lookup
                && lookup.TryGetValue(lookupKey, out var displayOption))
            {
                return displayOption;
            }

            return values[0]?.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
