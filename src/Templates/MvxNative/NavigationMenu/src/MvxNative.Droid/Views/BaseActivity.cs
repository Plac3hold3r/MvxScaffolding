using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace MvxNative.Droid.Views
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        protected abstract int ActivityLayoutId { get; }

        protected Toolbar Toolbar { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(ActivityLayoutId);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(Toolbar);
        }
    }
}
