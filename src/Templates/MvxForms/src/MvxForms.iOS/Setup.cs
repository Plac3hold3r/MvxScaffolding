using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.Platform;
using MvvmCross.iOS.Platform;
using MvxForms.Core;
using UIKit;

namespace MvxForms.iOS
{
    public class Setup : MvxFormsIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
            => new App();

        protected override MvxFormsApplication CreateFormsApplication()
            => new AppForms();
    }
}
