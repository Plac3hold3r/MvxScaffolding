using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvxFormsTemp.Core.ViewModels.Home;

namespace MvxFormsTemp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<HomeViewModel>();
        }
    }
}
