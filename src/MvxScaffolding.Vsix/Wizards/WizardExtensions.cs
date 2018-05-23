//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;

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

        public static void Update(this Dictionary<string, string> replacementsDictionary, string key, object value)
        {
            switch (value)
            {
                case bool boolValue:
                    replacementsDictionary[key] = boolValue.ToString().ToLowerInvariant();
                    break;

                case string stringValue:
                    replacementsDictionary[key] = stringValue;
                    break;
            }
        }

        public static string AsParameter(this string templateOption)
        {
            return $"$passthrough:{templateOption}$";
        }
    }
}
