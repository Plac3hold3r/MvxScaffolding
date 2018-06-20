using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxNative.Core.ViewModels.Main;
using MvxNative.Droid.Views.Helpers;

namespace MvxNative.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainContainerActivity : BaseActivity<MainContainerViewModel>, IDrawerActivity
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main_container;

        public DrawerLayout DrawerLayout { get; private set; }
        protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SetupDrawerLayout();
            DrawerToggle.SyncState();

            if (bundle == null)
                ViewModel.ShowMenuCommand.Execute();
        }

        private void SetupDrawerLayout()
        {
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

            DrawerToggle = new MvxActionBarDrawerToggle(
                this,                           // host Activity
                DrawerLayout,                   // DrawerLayout object
                Toolbar,                        // nav drawer icon to replace 'Up' caret
                Resource.String.drawer_open,    // "open drawer" description
                Resource.String.drawer_close    // "close drawer" description
            );

            DrawerToggle.DrawerOpened += (sender, e) => HideSoftKeyboard();
            DrawerLayout.AddDrawerListener(DrawerToggle);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            DrawerToggle.OnConfigurationChanged(newConfig);
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
                return;

            var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}
