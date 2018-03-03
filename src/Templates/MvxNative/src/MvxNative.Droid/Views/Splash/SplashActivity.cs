using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MvxNative.Droid.Views.Splash
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
    }
}
