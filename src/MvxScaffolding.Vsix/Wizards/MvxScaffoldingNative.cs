﻿//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Vsix.Wizards
{
    public class MvxScaffoldingNative : MvxScaffoldingBase
    {
        public MvxScaffoldingNative() : base(TemplateType.MvxNative)
        {
        }

        protected override void AddParameters(Dictionary<string, string> replacementsDictionary)
        {
            base.AddParameters(replacementsDictionary);

            replacementsDictionary.AddParameter(TemplateOptions.Native.HasAndroidUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasAndroidUiTestProject);
            replacementsDictionary.AddParameter(TemplateOptions.Native.HasIosUITestProject, MvxScaffoldingContext.UserSelectedOptions.HasIosUiTestProject);

            replacementsDictionary.AddParameter(TemplateOptions.Native.AndroidLayoutType, MvxScaffoldingContext.UserSelectedOptions.HasAndroidXml);
            replacementsDictionary.AddParameter(TemplateOptions.Native.IosLayoutType, MvxScaffoldingContext.UserSelectedOptions.HasIosFluentLayout);
        }
    }
}
