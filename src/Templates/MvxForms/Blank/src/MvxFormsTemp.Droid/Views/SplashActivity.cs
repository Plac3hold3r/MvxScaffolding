using System.Threading.Tasks;
using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MvxFormsTemp.Droid.Views
{
    [Activity(
       NoHistory = true,
       MainLauncher = true,
       Label = "@string/app_name",
       Theme = "@style/AppTheme.Splash")]
    public class SplashActivity : MvxFormsSplashScreenActivity<Setup, Core.App, UI.App>
    {
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}
