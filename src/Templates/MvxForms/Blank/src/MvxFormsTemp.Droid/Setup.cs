using Android.App;
using MvvmCross.Forms.Platforms.Android.Core;

//-:cnd:noEmit
#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif
//+:cnd:noEmit

namespace MvxFormsTemp.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
    }
}
