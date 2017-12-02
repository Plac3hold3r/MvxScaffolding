using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using MvxForms.Core;

//-:cnd:noEmit
#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif
//+:cnd:noEmit

namespace MvxForms.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
            => new App();

        protected override MvxFormsApplication CreateFormsApplication()
            => new UI.App();

        protected override IEnumerable<Assembly> GetViewAssemblies() => new List<Assembly>(base.GetViewAssemblies())
        {
            typeof(UI.App).GetTypeInfo().Assembly
        };
    }
}
