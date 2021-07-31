using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;

namespace MvxNative.UWP
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class MvxNativeApp : MvxApplication<Setup, Core.App>
    {
    }
}
