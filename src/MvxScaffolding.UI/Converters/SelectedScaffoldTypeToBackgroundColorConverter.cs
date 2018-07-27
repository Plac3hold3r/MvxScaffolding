//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.UI.Converters
{
    public class SelectedScaffoldTypeToBackgroundColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is ScaffoldType scaffoldType)
            {
                switch (scaffoldType)
                {
                    case ScaffoldType.SingleView:
                        return values[1];
                    case ScaffoldType.NavigationMenu:
                        return values[2];
                }
            }

            throw new ArgumentException($"Invalid type for {nameof(SelectedScaffoldTypeToBackgroundColorConverter)}", nameof(values));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
