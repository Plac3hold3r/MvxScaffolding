//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.Contexts
{
    public static class MvxScaffoldingContext
    {
        public static TemplateType CurrentTemplateType { get; set; }

        public static ITemplateOptions UserSelectedOptions { get; set; }
    }
}
