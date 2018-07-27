//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Vsix.Wizards
{
    public static class WizardExtensions
    {
        public static void AddParameter(this Dictionary<string, string> replacementsDictionary, string key, object value)
        {
            switch (value)
            {
                case bool boolValue:
                    replacementsDictionary.Add(key.AsParameter(), boolValue.ToString().ToLowerInvariant());
                    break;

                case string stringValue:
                    replacementsDictionary.Add(key.AsParameter(), stringValue);
                    break;
            }
        }

        public static string AsParameter(this string templateOption)
        {
            return $"$passthrough:{templateOption}$";
        }

        public static string AsParameter(this ScaffoldType templateOption)
        {
            switch (templateOption)
            {
                case ScaffoldType.SingleView:
                    return "single-view";
                case ScaffoldType.NavigationMenu:
                    return "navigation-menu";
                default:
                    throw new ArgumentOutOfRangeException(nameof(templateOption), $"No matching {nameof(ScaffoldType)} type");
            }
        }
    }
}
