//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TemplateWizard;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Files;
using MvxScaffolding.Core.Tasks;
using MvxScaffolding.Core.Template;
using MvxScaffolding.UI;
using MvxScaffolding.UI.Threading;

namespace MvxScaffolding.Vsix.Wizards
{
    public abstract class MvxScaffoldingBase : IWizard
    {
        protected MvxScaffoldingBase(TemplateType templateType)
        {
            MvxScaffoldingContext.CurrentTemplateType = templateType;
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            // Method intentionally left empty.
        }

        public void ProjectFinishedGenerating(Project project)
        {
            // Method intentionally left empty.
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            // Method intentionally left empty.
        }

        public void RunFinished()
        {
            // Method intentionally left empty.
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            if (runKind == WizardRunKind.AsNewProject || runKind == WizardRunKind.AsMultiProject)
            {
                MvxScaffoldingContext.WizardVersion = new Version(ThisAssembly.Vsix.Version);
                MvxScaffoldingContext.WizardName = ThisAssembly.Vsix.Name;

                UpdateSolutionDirectory(automationObject, replacementsDictionary);

                try
                {
                    ShowModal(Startup.FirstView());

                    MvxScaffoldingContext.RunningTimer.Stop();

                    if (MvxScaffoldingContext.UserSelectedOptions is null)
                    {
                        var projectDirectory = replacementsDictionary[VSTemplateKeys.DestinationDirectory];
                        var solutionDirectory = replacementsDictionary[VSTemplateKeys.SolutionDirectory];

                        CleanupDirectories(projectDirectory, solutionDirectory);

                        Logger.Current.Telemetry.TrackWizardCancelledAsync(MvxScaffoldingContext.RunningTimer.Elapsed.TotalSeconds)
                            .FireAndForget();

                        throw new WizardBackoutException();
                    }
                    else
                    {
                        Logger.Current.Telemetry.TrackProjectGenAsync(MvxScaffoldingContext.UserSelectedOptions, MvxScaffoldingContext.RunningTimer.Elapsed.TotalSeconds)
                            .FireAndForget();

                        UpdateReplacementsDictionary(replacementsDictionary);

                        MvxScaffoldingContext.UserSelectedOptions = null;
                    }
                }
                finally
                {
                    Logger.Current.Telemetry.TrackEndSessionAsync()
                        .FireAndForget();
                }
            }
        }

        private static void UpdateSolutionDirectory(object automationObject, Dictionary<string, string> replacementsDictionary)
        {
            var dte = (DTE)automationObject;
            var solution = (Solution2)dte.Solution;
            solution.Close();

            var oldDestinationDirectory = replacementsDictionary[VSTemplateKeys.DestinationDirectory];
            if (Directory.Exists(oldDestinationDirectory))
            {
                Directory.Delete(oldDestinationDirectory, true);
            }

            var newDestinationDirectory = Path.Combine($"{oldDestinationDirectory}", @"..\");
            replacementsDictionary[VSTemplateKeys.DestinationDirectory] = Path.GetFullPath(newDestinationDirectory);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        protected virtual void UpdateReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            replacementsDictionary.AddParameter(TemplateOptions.HasAndroidProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroid);
            replacementsDictionary.AddParameter(TemplateOptions.HasIosProject, MvxScaffoldingContext.UserSelectedOptions.HasIos);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpProject, MvxScaffoldingContext.UserSelectedOptions.HasUwp);

            replacementsDictionary.AddParameter(TemplateOptions.HasCoreTestProject, MvxScaffoldingContext.UserSelectedOptions.HasCoreUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasAndroidTestProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroidUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasIosTestProject, MvxScaffoldingContext.UserSelectedOptions.HasIosUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpTestProject, MvxScaffoldingContext.UserSelectedOptions.HasUwpUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasUwpUiTestProject);

            replacementsDictionary.AddParameter(TemplateOptions.MvvmCrossVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMvvmCrossVersion);
            replacementsDictionary.AddParameter(TemplateOptions.HasEditorConfig, MvxScaffoldingContext.UserSelectedOptions.HasEditorConfig);
            replacementsDictionary.AddParameter(TemplateOptions.SolutionProjectGrouping, MvxScaffoldingContext.UserSelectedOptions.SelectedProjectGrouping);

            replacementsDictionary.AddParameter(TemplateOptions.AppId, MvxScaffoldingContext.UserSelectedOptions.AppId);
            replacementsDictionary.AddParameter(TemplateOptions.AppName, MvxScaffoldingContext.UserSelectedOptions.AppName);
            replacementsDictionary.AddParameter(TemplateOptions.NetStandardVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedNetStandard);

            replacementsDictionary.AddParameter(TemplateOptions.AndroidMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinAndroidSDK);

            replacementsDictionary.AddParameter(TemplateOptions.IosMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinIosSDK);
            replacementsDictionary.AddParameter(TemplateOptions.HasHyperion, MvxScaffoldingContext.UserSelectedOptions.HasIosHyperion);

            replacementsDictionary.AddParameter(TemplateOptions.UwpMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinUwpSDK);
            replacementsDictionary.AddParameter(TemplateOptions.UwpAppDescription, MvxScaffoldingContext.UserSelectedOptions.UwpDescription);
        }

        public void ShowModal(System.Windows.Window dialog)
        {
            SafeThreading.JoinableTaskFactory.SwitchToMainThreadAsync();

            UIShell.GetDialogOwnerHwnd(out IntPtr hwnd);

            dialog.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            UIShell.EnableModeless(0);

            try
            {
                WindowHelper.ShowModal(dialog, hwnd);
            }
            finally
            {
                UIShell.EnableModeless(1);
            }
        }

        private readonly Lazy<IVsUIShell> _uiShell = new Lazy<IVsUIShell>(() =>
        {
            SafeThreading.JoinableTaskFactory.SwitchToMainThreadAsync();
            return ServiceProvider.GlobalProvider.GetService(typeof(SVsUIShell)) as IVsUIShell;
        }, true);

        private IVsUIShell UIShell => _uiShell.Value;

        private void CleanupDirectories(string projectDirectory, string solutionDirectory)
        {
            FileSystemUtils.SafeDeleteDirectory(projectDirectory);

            if (Directory.Exists(solutionDirectory)
                && !Directory.EnumerateDirectories(solutionDirectory).Any()
                && !Directory.EnumerateFiles(solutionDirectory).Any())
            {
                FileSystemUtils.SafeDeleteDirectory(solutionDirectory);
            }
        }
    }
}
