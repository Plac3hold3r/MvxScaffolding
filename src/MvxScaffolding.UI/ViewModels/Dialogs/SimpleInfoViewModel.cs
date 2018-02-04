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
    }
}
