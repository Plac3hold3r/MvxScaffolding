using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using System.Collections.Generic;
using System.Reflection;

//-:cnd:noEmit
#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif
//+:cnd:noEmit

namespace MvxFormsTemp.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
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
