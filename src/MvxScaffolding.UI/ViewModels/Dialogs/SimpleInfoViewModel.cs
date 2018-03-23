//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Template;
using MvxScaffolding.Localization.Resources;

namespace MvxScaffolding.UI.ViewModels.Dialogs
{
    public class SimpleInfoViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string ReadMoreLink { get; set; }

        public string TemplateLink { get; set; }

        public static SimpleInfoViewModel PrivacyInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_Privacy_Title,
                Message = LocalResources.SimpleInfo_Privacy_Desc,
                ReadMoreLink = Config.Current.PrivacyPolicyUri,
                TemplateLink = TemplateLinks.PrivacyPolicy
            };
        }

        public static SimpleInfoViewModel TranslateInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_Translate_Title,
                Message = LocalResources.SimpleInfo_Translate_Desc,
                ReadMoreLink = Config.Current.HelpTranslateUri,
                TemplateLink = TemplateLinks.HelpTranslate
            };
        }

        public static SimpleInfoViewModel EditorConfigInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_EditorConfig_Title,
                Message = LocalResources.SimpleInfo_EditorConfig_Desc,
                ReadMoreLink = Config.Current.EditorConfigUri,
                TemplateLink = TemplateLinks.EditorConfig
            };
        }

        public static SimpleInfoViewModel AndroidXmlLayoutInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_Xml_Layouts_Title,
                Message = LocalResources.SimpleInfo_Xml_Layouts_Desc
            };
        }

        public static SimpleInfoViewModel IosFluentLayoutsInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_Fluent_Layouts_Title,
                Message = LocalResources.SimpleInfo_Fluent_Layouts_Desc,
                ReadMoreLink = Config.Current.FluentLayoutUri,
                TemplateLink = TemplateLinks.FluentLayout
            };
        }

        public static SimpleInfoViewModel IosHyperionInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = LocalResources.SimpleInfo_Hyperion_Title,
                Message = LocalResources.SimpleInfo_Hyperion_Desc,
                ReadMoreLink = Config.Current.HyperioniOSUri,
                TemplateLink = TemplateLinks.HyperioniOS
            };
        }
    }
}
