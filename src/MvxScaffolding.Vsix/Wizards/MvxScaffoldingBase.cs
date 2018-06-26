//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
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
                MvxScaffoldingContext.ProjectName = replacementsDictionary[VSTemplateKeys.ProjectName];
                MvxScaffoldingContext.SafeProjectName = replacementsDictionary[VSTemplateKeys.SafeProjectName];
                MvxScaffoldingContext.SolutionName = replacementsDictionary[VSTemplateKeys.SpecifiedSolutionName];

                RemoveOldSolutionDirectory(automationObject, replacementsDictionary);

                try
                {
                    ShowModal(Startup.FirstView());

                    MvxScaffoldingContext.RunningTimer.Stop();

                    if (MvxScaffoldingContext.UserSelectedOptions is null)
                    {
                        Logger.Current.Telemetry.TrackWizardCancelledAsync(MvxScaffoldingContext.RunningTimer.Elapsed.TotalSeconds)
                            .FireAndForget();

                        throw new WizardBackoutException();
                    }
                    else
                    {
                        Logger.Current.Telemetry.TrackProjectGenAsync(MvxScaffoldingContext.UserSelectedOptions, MvxScaffoldingContext.RunningTimer.Elapsed.TotalSeconds)
                            .FireAndForget();

                        AddParameters(replacementsDictionary);
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

        private static void RemoveOldSolutionDirectory(object automationObject, Dictionary<string, string> replacementsDictionary)
        {
            var dte = (DTE)automationObject;
            var solution = (Solution2)dte.Solution;
            solution.Close();

            var oldDestinationDirectory = replacementsDictionary[VSTemplateKeys.DestinationDirectory];
            var solutionRootDirectory = Path.GetFullPath(Path.Combine(oldDestinationDirectory, @"..\"));

            FileSystemUtils.SafeDeleteDirectory(solutionRootDirectory);

            var rootFolderDictionary = Path.GetFullPath(Path.Combine(solutionRootDirectory, @"..\"));
            replacementsDictionary[VSTemplateKeys.DestinationDirectory] = rootFolderDictionary;
            replacementsDictionary[VSTemplateKeys.SolutionDirectory] = rootFolderDictionary;
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        protected virtual void AddParameters(Dictionary<string, string> replacementsDictionary)
        {
            replacementsDictionary.AddParameter(TemplateOptions.HasAndroidProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroid);
            replacementsDictionary.AddParameter(TemplateOptions.HasIosProject, MvxScaffoldingContext.UserSelectedOptions.HasIos);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpProject, MvxScaffoldingContext.UserSelectedOptions.HasUwp);

            replacementsDictionary.AddParameter(TemplateOptions.HasCoreTestProject, MvxScaffoldingContext.UserSelectedOptions.HasCoreUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasAndroidTestProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroidUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasIosTestProject, MvxScaffoldingContext.UserSelectedOptions.HasIosUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpTestProject, MvxScaffoldingContext.UserSelectedOptions.HasUwpUnitTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.HasUwpUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasUwpUiTestProject);

            replacementsDictionary.AddParameter(TemplateOptions.HasEditorConfig, MvxScaffoldingContext.UserSelectedOptions.HasEditorConfig);
            replacementsDictionary.AddParameter(TemplateOptions.SolutionProjectGrouping, MvxScaffoldingContext.UserSelectedOptions.SelectedProjectGrouping);

            replacementsDictionary.AddParameter(TemplateOptions.AppId, MvxScaffoldingContext.UserSelectedOptions.AppId);
            replacementsDictionary.AddParameter(TemplateOptions.AppName, MvxScaffoldingContext.UserSelectedOptions.AppName);
            replacementsDictionary.AddParameter(TemplateOptions.SolutionName, MvxScaffoldingContext.UserSelectedOptions.SolutionName);
            replacementsDictionary.AddParameter(TemplateOptions.NetStandardVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedNetStandard);

            replacementsDictionary.AddParameter(TemplateOptions.AndroidMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinAndroidSDK);

            replacementsDictionary.AddParameter(TemplateOptions.IosMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinIosSDK);

            replacementsDictionary.AddParameter(TemplateOptions.UwpMinSdkVersion, MvxScaffoldingContext.UserSelectedOptions.SelectedMinUwpSDK);
            replacementsDictionary.AddParameter(TemplateOptions.UwpAppDescription, MvxScaffoldingContext.UserSelectedOptions.UwpDescription);
        }

        public void UpdateReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            replacementsDictionary[VSTemplateKeys.SpecifiedSolutionName] = MvxScaffoldingContext.UserSelectedOptions.SolutionName;
            replacementsDictionary[VSTemplateKeys.SolutionDirectory] += MvxScaffoldingContext.UserSelectedOptions.SolutionName;
            replacementsDictionary[VSTemplateKeys.DestinationDirectory] += MvxScaffoldingContext.UserSelectedOptions.SolutionName + "\\";
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
    }
}
