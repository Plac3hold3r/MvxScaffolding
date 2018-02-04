using MvxScaffolding.UI.Properties;

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
                ReadMoreLink = Settings.Default.PrivacyPolicyUri // TODO [JF] :: get the correct policy Uri
            };
        }

        public static SimpleInfoViewModel ProjectGroupInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "Project Grouping",
                Message = "The grouping for projects into folders inside of the solution.&#x0a;&#x0a;• Select &quot;Flat&quot; for when you want all projects to be placed at the root of the solution.&#x0a;&#x0a;• Select &quot;Test Group&quot; for when you want all test projects to be placed in a test folder, other projects are placed at the root of the solution.&#x0a;&#x0a;• Select &quot;Platform&quot; if you want projects to be grouped based on their target platform.",
            };
        }

        public static SimpleInfoViewModel EditorConfigInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "EditorConfig",
                Message = "Enable to include an EditorConfig file at the root of the solution. EditorConfig is used to define coding styles enforced within Visual Studio.",
                ReadMoreLink = "https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options"
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
                ReadMoreLink = "https://github.com/FluentLayout/Cirrious.FluentLayout"
            };
        }

        public static SimpleInfoViewModel IosHyperionInfo()
        {
            return new SimpleInfoViewModel
            {
                Title = "Hyperion",
                Message = "Enable to include Hyperion, an in app design review tool.",
                ReadMoreLink = "https://github.com/willowtreeapps/Hyperion-iOS"
            };
        }
    }
}
