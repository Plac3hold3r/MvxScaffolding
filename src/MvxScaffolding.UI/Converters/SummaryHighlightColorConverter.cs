using System;
using System.Globalization;
using System.Windows.Data;
using MvxScaffolding.UI.Styles;

namespace MvxScaffolding.UI.Converters
{
    public class SummaryHighlightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valueBool)
                return valueBool
                    ? MvxScaffoldingColorResource.PrimaryBrush
                    : MvxScaffoldingColorResource.MaterialDesignBodyBrush;

            return MvxScaffoldingColorResource.MaterialDesignBodyBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
