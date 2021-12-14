//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TemplateWizard;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Vsix.Constants;

namespace MvxScaffolding.Vsix.Wizards
{
    public class MvxScaffoldingDirectoryFix : IWizard
    {
        private DTE _dte;
        private string _destinationDirectory;
        private string _solutionName;

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
            ThreadHelper.ThrowIfNotOnUIThread();

            var solution = (Solution2)_dte.Solution;
            var pathToNewSolution = Path.Combine(_destinationDirectory, _solutionName + ".sln");
            solution.Open(pathToNewSolution);
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _dte = (DTE)automationObject;
            _destinationDirectory = replacementsDictionary[VSTemplateKeys.DestinationDirectory];
            _solutionName = replacementsDictionary[TemplateOptions.SolutionName.AsParameter()];
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return false;
        }
    }
}
