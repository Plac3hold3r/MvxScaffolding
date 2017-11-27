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
using Xamarin.Forms;

namespace MvxForms.Droid.Views
{
    [Activity(
       NoHistory = true,
       MainLauncher = true,
       Label = "@string/app_name",
       Theme = "@style/AppTheme.Splash",
       Icon = "@mipmap/ic_launcher",
       RoundIcon = "@mipmap/ic_launcher_round")]
    public class SplashActivity : MvxSplashScreenAppCompatActivity
    {
        private bool isInitializationComplete = false;
        public override void InitializationComplete()
        {
            if (!isInitializationComplete)
            {
                isInitializationComplete = true;
                StartActivity(typeof(MainApplicationActivity));
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            Forms.Init(this, bundle);
            // Leverage controls' StyleId attrib. to Xamarin.UITest
            Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            base.OnCreate(bundle);
        }
    }
}
