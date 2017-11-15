using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvxNative.Core;
using UIKit;

namespace MvxNative.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
            => new App();
    }
}
