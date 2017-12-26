using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Platform;
using MvxFormsTemp.iOS.Styles;
using UIKit;

namespace MvxFormsTemp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.BarTintColor = ColorPalette.Primary;
            UINavigationBar.Appearance.TintColor = ColorPalette.SecondaryText;

            var setup = new Setup(this, Window);
            setup.Initialize();

            IMvxAppStart startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            LoadApplication(setup.FormsApplication);

            Window.MakeKeyAndVisible();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
