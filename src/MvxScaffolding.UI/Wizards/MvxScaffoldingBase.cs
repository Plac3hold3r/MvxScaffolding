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

                ShowModal(new MainWindow());

                if (MvxScaffoldingContext.UserSelectedOptions is null)
                {
                    var projectDirectory = replacementsDictionary["$destinationdirectory$"];
                    var solutionDirectory = replacementsDictionary["$solutiondirectory$"];

                    CleanupDirectories(projectDirectory, solutionDirectory);

                    throw new WizardBackoutException();
                }
                else
                {
                    UpdateReplacementsDictionary(replacementsDictionary);
                }
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        protected virtual void UpdateReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            replacementsDictionary.Add("$passthrough:HasAndroidProject$", MvxScaffoldingContext.UserSelectedOptions.HasAndroid.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasiOSProject$", MvxScaffoldingContext.UserSelectedOptions.HasIos.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasUWPProject$", MvxScaffoldingContext.UserSelectedOptions.HasUwp.ToString().ToLowerInvariant());

            replacementsDictionary.Add("$passthrough:HasCoreTestProject$", MvxScaffoldingContext.UserSelectedOptions.HasCoreUnitTestProject.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasAndroidTestProject$", MvxScaffoldingContext.UserSelectedOptions.HasAndroidUnitTestProject.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasiOSTestProject$", MvxScaffoldingContext.UserSelectedOptions.HasIosUnitTestProject.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasUWPTestProject$", MvxScaffoldingContext.UserSelectedOptions.HasUwpUnitTestProject.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasUWPUITestProject$", MvxScaffoldingContext.UserSelectedOptions.HasUwpUiTestProject.ToString().ToLowerInvariant());

            replacementsDictionary.Add("$passthrough:HasEditorConfig$", MvxScaffoldingContext.UserSelectedOptions.HasEditorConfig.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:SolutionProjectGrouping$", MvxScaffoldingContext.UserSelectedOptions.SelectedProjectGrouping);

            replacementsDictionary.Add("$passthrough:AppId$", MvxScaffoldingContext.UserSelectedOptions.AppId);
            replacementsDictionary.Add("$passthrough:AppName$", MvxScaffoldingContext.UserSelectedOptions.AppName);
            replacementsDictionary.Add("$passthrough:NETStandardVersion$", MvxScaffoldingContext.UserSelectedOptions.SelectedNetStandard);

            replacementsDictionary.Add("$passthrough:AndroidMinSDKVersion$", MvxScaffoldingContext.UserSelectedOptions.SelectedMinAndroidSDK);

            replacementsDictionary.Add("$passthrough:iOSMinSDKVersion$", MvxScaffoldingContext.UserSelectedOptions.SelectedMinIosSDK);
            replacementsDictionary.Add("$passthrough:HasHyperion$", MvxScaffoldingContext.UserSelectedOptions.HasIosHyperion.ToString().ToLowerInvariant());

            replacementsDictionary.Add("$passthrough:UWPMinSDKVersion$", MvxScaffoldingContext.UserSelectedOptions.SelectedMinUwpSDK);

            if (!string.IsNullOrWhiteSpace(MvxScaffoldingContext.UserSelectedOptions.UwpDescription))
                replacementsDictionary.Add("$passthrough:UWPAppDescription$", MvxScaffoldingContext.UserSelectedOptions.UwpDescription);
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
