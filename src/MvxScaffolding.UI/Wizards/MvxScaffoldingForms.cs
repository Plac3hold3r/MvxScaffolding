//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.UI.Contexts;
using MvxScaffolding.UI.Template;
using System.Collections.Generic;

namespace MvxScaffolding.UI.Wizards
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
