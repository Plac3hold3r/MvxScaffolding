using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvxNative.Core.ViewModels.Main;

namespace MvxNative.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
