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
using Microsoft.VisualStudio.Threading;
using MvxScaffolding.UI.Diagnostics;
using MvxScaffolding.UI.Helpers;
using MvxScaffolding.UI.Views;

namespace MvxScaffolding.UI.Wizards
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
                UpdateSolutionDirectory(automationObject, replacementsDictionary);

                try
                {
                    ShowModal(new MainWindow());

                    if (MvxScaffoldingContext.UserSelectedOptions is null)
                    {
                        var projectDirectory = replacementsDictionary["$destinationdirectory$"];
                        var solutionDirectory = replacementsDictionary["$solutiondirectory$"];

                        CleanupDirectories(projectDirectory, solutionDirectory);
                        Logger.Current.Telemetry.TrackWizardStatusAsync(WizardStatus.Cancelled).FireAndForget();

                        throw new WizardBackoutException();
                    }
                    else
                    {
                        UpdateReplacementsDictionary(replacementsDictionary);
                        Logger.Current.Telemetry.TrackWizardStatusAsync(WizardStatus.Completed).FireAndForget();
                    }
                }
                finally
                {
                    Logger.Current.Telemetry.TrackEndSessionAsync().FireAndForget();
                }
            }
        }

        private static void UpdateSolutionDirectory(object automationObject, Dictionary<string, string> replacementsDictionary)
        {
            var dte = (DTE)automationObject;
            var solution = (Solution2)dte.Solution;
            solution.Close();

            var oldDestinationDirectory = replacementsDictionary["$destinationdirectory$"];
            if (Directory.Exists(oldDestinationDirectory))
            {
                Directory.Delete(oldDestinationDirectory, true);
            }

            var newDestinationDirectory = Path.Combine($"{oldDestinationDirectory}", @"..\");
            replacementsDictionary["$destinationdirectory$"] = Path.GetFullPath(newDestinationDirectory);
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

        public static class SafeThreading
        {
            public static JoinableTaskFactory JoinableTaskFactory { get; set; }

            static SafeThreading()
            {
                try
                {
                    JoinableTaskFactory = ThreadHelper.JoinableTaskFactory;
                }
                catch (NullReferenceException)
                {
                    var context = new JoinableTaskContext(System.Threading.Thread.CurrentThread);
                    JoinableTaskCollection collection = context.CreateCollection();
                    JoinableTaskFactory = context.CreateFactory(collection);
                }
            }
        }
    }
}
