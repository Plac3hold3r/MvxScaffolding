using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxFormsTemp.Core.ViewModels.Home;

namespace MvxFormsTemp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}
