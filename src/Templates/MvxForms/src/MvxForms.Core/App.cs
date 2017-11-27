using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvxForms.Core.ViewModels.Main;

namespace MvxForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
