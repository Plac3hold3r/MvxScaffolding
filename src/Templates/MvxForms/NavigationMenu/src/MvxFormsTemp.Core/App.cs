using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxFormsTemp.Core.ViewModels.Root;

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

            RegisterAppStart<RootViewModel>();
        }
    }
}
