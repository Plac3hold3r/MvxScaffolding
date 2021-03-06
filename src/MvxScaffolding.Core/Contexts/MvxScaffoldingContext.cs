//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using MvxScaffolding.Core.Dialogs.Interfaces;
using MvxScaffolding.Core.Files;
using MvxScaffolding.Core.Properties;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.Contexts
{
    public static class MvxScaffoldingContext
    {
        public static TemplateType CurrentTemplateType { get; set; }

        public static ITemplateOptions UserSelectedOptions { get; set; }

        public static IDialogHost DialogHost { get; set; }

        public static Stopwatch RunningTimer { get; set; }

        public static Version WizardVersion { get; set; } = new Version("0.0.1");

        public static string WizardName { get; set; } = "MvxScaffolding";

        public static string ProjectName { get; set; } = "Test Project";

        public static string SafeProjectName { get; set; } = "Test_Project";

        public static string SolutionName { get; set; } = "SolutionProject";

        public static FileDeleteStatus RemoveOldSolutionDirectoryStatus { get; set; } = FileDeleteStatus.Unknown;

        public static bool CanCreateSolutionDirectory { get; set; }

        public static Version LastKnownVersion
        {
            get => Version.TryParse(Settings.Default.LastKnownVersion, out Version version) ? version : null;
            set
            {
                Settings.Default.LastKnownVersion = value.ToString();
                Settings.Default.Save();
            }
        }
    }
}
