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
using MvvmCross.Droid.Support.V4;
using MvxNative.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace MvxNative.Droid.Views
{
    public abstract class BaseFragment<TViewModel> : MvxFragment<TViewModel>
        where TViewModel : BaseViewModel
    {
        protected abstract int FragmentLayoutId { get; }

        #region Fragment Life Cycle

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(FragmentLayoutId, null);
        }

        #endregion Fragment Life Cycle
    }
}
