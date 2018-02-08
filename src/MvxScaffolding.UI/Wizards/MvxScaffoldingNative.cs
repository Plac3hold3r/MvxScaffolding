using System.Collections.Generic;
using MvxScaffolding.UI.Helpers;

namespace MvxScaffolding.UI.Wizards
{
    public class MvxScaffoldingNative : MvxScaffoldingBase
    {
        public MvxScaffoldingNative() : base(TemplateType.MvxNative)
        {

        }

        protected override void UpdateReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            base.UpdateReplacementsDictionary(replacementsDictionary);

            replacementsDictionary.Add("$passthrough:HasAndroidUITestProject$", MvxScaffoldingContext.UserSelectedOptions.HasAndroidUiTestProject.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasiOSUITestProject$", MvxScaffoldingContext.UserSelectedOptions.HasIosUiTestProject.ToString().ToLowerInvariant());

            replacementsDictionary.Add("$passthrough:UseAndroidXMLLayouts$", MvxScaffoldingContext.UserSelectedOptions.HasAndroidXml.ToString().ToLowerInvariant());
            replacementsDictionary.Add("$passthrough:HasFluentLayouts$", MvxScaffoldingContext.UserSelectedOptions.HasIosFluentLayout.ToString().ToLowerInvariant());
        }
    }
}
