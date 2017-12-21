using Android.App;
using Android.OS;
using MvvmCross.Forms.Droid.Views;
using MvxForms.Core.ViewModels.Main;

namespace MvxForms.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
        }

        public override void OnBackPressed()
        {
            MoveTaskToBack(false);
        }
    }
}
