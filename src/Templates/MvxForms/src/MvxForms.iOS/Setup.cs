using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.Platform;
using MvvmCross.iOS.Platform;
using UIKit;

namespace MvxForms.iOS
{
    public class Setup : MvxFormsIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
            => new Core.App();

        protected override MvxFormsApplication CreateFormsApplication()
            => new UI.App();

        protected override IEnumerable<Assembly> GetViewAssemblies() => new List<Assembly>(base.GetViewAssemblies())
        {
            typeof(UI.App).GetTypeInfo().Assembly
        };
    }
}
