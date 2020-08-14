using System;

using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvxNative.Core;

namespace MvxNative.Droid
{
    //-:cnd:noEmit
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    //+:cnd:noEmit
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
