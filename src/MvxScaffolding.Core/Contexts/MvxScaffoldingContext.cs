//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using MvxScaffolding.Core.Properties;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.Contexts
{
    public static class MvxScaffoldingContext
    {
        public static TemplateType CurrentTemplateType { get; set; }

        public static ITemplateOptions UserSelectedOptions { get; set; }

        public static Stopwatch RunningTimer { get; set; }

        public static Version WizardVersion { get; set; } = new Version("0.0.1");

        public static string WizardName { get; set; } = "MvxScaffolding";

        public static Version LastKnownVersion
        {
            get => Settings.Default.LastKnownVersion;
            set
            {
                Settings.Default.LastKnownVersion = value;
                Settings.Default.Save();
            }
        }
    }
}
