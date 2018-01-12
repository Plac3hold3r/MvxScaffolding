using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;

namespace MvxScaffolding.UI.Wizards
{
    public abstract class MvxScaffoldingBase : IWizard
    {
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
            // Close new solution
            var dte = (DTE)automationObject;
            var solution = (Solution2)dte.Solution;
            solution.Close();

            // Delete old directory(in my case VS creating it) and change destination
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
    }
}
