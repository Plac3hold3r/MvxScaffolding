using MvxScaffolding.UI.Helpers;
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
