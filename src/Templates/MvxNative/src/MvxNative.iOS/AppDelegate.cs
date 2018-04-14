using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvxNative.Core;

namespace MvxNative.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
    }
}
