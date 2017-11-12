using MvvmCross.Core.ViewModels;
using MvxNative.Core.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxNative.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
