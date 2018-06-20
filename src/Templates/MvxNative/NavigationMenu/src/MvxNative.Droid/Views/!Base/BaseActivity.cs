using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;

namespace MvxNative.Droid.Views
{
    public abstract class BaseActivity<TViewModel> : MvxAppCompatActivity<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        protected abstract int ActivityLayoutId { get; }

        protected Toolbar Toolbar => FindViewById<Toolbar>(Resource.Id.toolbar);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(ActivityLayoutId);

            SetSupportActionBar(Toolbar);
        }
    }
}
