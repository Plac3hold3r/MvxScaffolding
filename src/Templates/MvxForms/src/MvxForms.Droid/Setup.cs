using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
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
            => new AppForms();
    }
}
