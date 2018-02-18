//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Vsix.Wizards
{
    public class MvxScaffoldingForms : MvxScaffoldingBase
    {
        public MvxScaffoldingForms() : base(TemplateType.MvxForms)
        {
        }

        protected override void UpdateReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            base.UpdateReplacementsDictionary(replacementsDictionary);

            replacementsDictionary.AddParameter(TemplateOptions.Forms.HasXamarinUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroidUiTestProject);
        }
    }
}
