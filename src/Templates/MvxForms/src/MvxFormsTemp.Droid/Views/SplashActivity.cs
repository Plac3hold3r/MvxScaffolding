using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MvxFormsTemp.Droid.Views
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
        protected override void TriggerFirstNavigate()
        {
            StartActivity(typeof(MainActivity));
            base.TriggerFirstNavigate();
        }
    }
}
