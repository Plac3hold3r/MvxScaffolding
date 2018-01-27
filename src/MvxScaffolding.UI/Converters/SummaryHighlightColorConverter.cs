using System;
using System.Globalization;
using System.Windows.Data;

namespace MvxScaffolding.UI.Converters
{
    public class SummaryHighlightColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool valueBool)
                return valueBool
                    ? values[1]
                    : values[2];

            return values[2];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
