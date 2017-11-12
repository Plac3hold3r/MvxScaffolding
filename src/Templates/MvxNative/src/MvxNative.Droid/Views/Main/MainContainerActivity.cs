using Android.App;
using Android.Widget;
using Android.OS;
using MvxNative.Core.ViewModels.Main;
using Android.Views;

namespace MvxNative.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainContainerActivity : BaseActivity<MainContainerViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main_container;
    }
}
