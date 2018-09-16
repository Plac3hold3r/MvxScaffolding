using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxNative.Core.ViewModels.Main;

namespace MvxNative.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main_container);
        }
    }
}
