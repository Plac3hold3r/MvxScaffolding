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
    public class ProjectGroupToLocalizedString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string projectGroupOption
                && TemplateChoices.ProjectGroupingOptions.TryGetValue(projectGroupOption, out string displayOption))
            {
                return displayOption;
            }

            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
