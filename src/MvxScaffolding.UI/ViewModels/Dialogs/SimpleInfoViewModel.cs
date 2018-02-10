using MvxScaffolding.UI.Configuration;

namespace MvxScaffolding.UI.ViewModels.Dialogs
{
    public class SimpleInfoViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ReadMoreLink { get; set; }

        public static SimpleInfoViewModel PrivacyInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "Privacy",
                Message = "This template wizard makes use of 3rd party crash and analytics reporting. See the privacy policy for more details.",
                ReadMoreLink = Config.Current.PrivacyPolicyUri // TODO [JF] :: get the correct policy Uri
            };
        }

        public static SimpleInfoViewModel EditorConfigInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "EditorConfig",
                Message = "Enable to include an EditorConfig file at the root of the solution. EditorConfig is used to define coding styles highlighted within Visual Studio.",
                ReadMoreLink = Config.Current.EditorConfigUri
            };
        }

        public static SimpleInfoViewModel AndroidXmlLayoutInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "XML Layouts",
                Message = "Enable to use XML layouts instead of Xamarin default AXML layouts."
            };
        }

        public static SimpleInfoViewModel IosFluentLayoutsInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "Fluent Layouts",
                Message = "Enable to include FluentLayout, a fluent API for creating constraint-based layouts.",
                ReadMoreLink = Config.Current.FluentLayoutUri
            };
        }

        public static SimpleInfoViewModel IosHyperionInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "Hyperion",
                Message = "Enable to include Hyperion, an in app design review tool.",
                ReadMoreLink = Config.Current.HyperioniOSUri
            };
        }
    }
}
