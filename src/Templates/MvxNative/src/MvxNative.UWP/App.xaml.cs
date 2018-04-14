using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;

namespace MvxNative.UWP
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class MvxNativeApp : MvxApplication<MvxWindowsSetup<Core.App>, Core.App>
    {
    }
}
