using System.Collections.Generic;

namespace MvxScaffolding.UI.Wizards
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
    }
}
