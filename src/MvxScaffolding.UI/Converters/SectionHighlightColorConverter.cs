using System;
using System.Globalization;
using System.Windows.Data;
using MvxScaffolding.UI.Styles;

namespace MvxScaffolding.UI.Converters
{
    public class SectionHighlightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int valueInt
                && int.TryParse(parameter?.ToString(), out int parameterInt))
                return valueInt == parameterInt
                    ? MvxScaffoldingColorResource.PrimaryBrush
                    : MvxScaffoldingColorResource.MaterialDesignBodyLightBrush;

            return MvxScaffoldingColorResource.MaterialDesignBodyLightBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
