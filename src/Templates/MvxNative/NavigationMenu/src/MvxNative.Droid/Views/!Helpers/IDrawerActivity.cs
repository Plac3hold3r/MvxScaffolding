using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MvxNative.Droid.Views.Helpers
{
    public interface IDrawerActivity
    {
        DrawerLayout DrawerLayout { get; }

        ActionBar SupportActionBar { get; }

        void HideSoftKeyboard();
    }
}
