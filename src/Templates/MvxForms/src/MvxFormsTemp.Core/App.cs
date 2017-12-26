using MvvmCross.Core.ViewModels;
using MvxFormsTemp.Core.ViewModels.Home;

namespace MvxFormsTemp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<HomeViewModel>();
        }
    }
}
