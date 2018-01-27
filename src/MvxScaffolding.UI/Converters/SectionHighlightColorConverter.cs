using System;
using System.Globalization;
using System.Windows.Data;

namespace MvxScaffolding.UI.Converters
{
    public class SectionHighlightColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int valueInt
                && int.TryParse(parameter?.ToString(), out int parameterInt))
                return valueInt == parameterInt
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
