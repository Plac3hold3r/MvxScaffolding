using MvvmCross.Core.ViewModels;
using MvxForms.Core.ViewModels.Home;

namespace MvxForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<HomeViewModel>();
        }
    }
}
