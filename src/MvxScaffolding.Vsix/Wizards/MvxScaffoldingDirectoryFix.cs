//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using MvxScaffolding.Core.Template;

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
            var solution = (Solution2)_dte.Solution;
            var pathToOldSolution = Path.Combine(_destinationDirectory, _solutionName + ".sln");
            solution.Open(pathToOldSolution);
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = (DTE)automationObject;
            _destinationDirectory = replacementsDictionary[VSTemplateKeys.DestinationDirectory];
            _solutionName = replacementsDictionary[VSTemplateKeys.SpecifiedSolutionName];
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return false;
        }
    }
}
