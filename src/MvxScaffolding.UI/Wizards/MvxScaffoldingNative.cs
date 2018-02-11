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

            replacementsDictionary.AddParameter(TemplateOptions.Native.HasAndroidUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroidUiTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.Native.HasIosUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasIosUiTestProject);

            replacementsDictionary.AddParameter(TemplateOptions.Native.UseAndroidXmlLayouts, MvxScaffoldingContext.UserSelectedOptions.HasAndroidXml);
            replacementsDictionary.AddParameter(TemplateOptions.Native.HasFluentLayouts, MvxScaffoldingContext.UserSelectedOptions.HasIosFluentLayout);
        }
    }
}
