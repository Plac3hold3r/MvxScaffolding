using MvvmCross.ViewModels;
using MvxNative.Core.ViewModels.Main;

namespace MvxNative.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
