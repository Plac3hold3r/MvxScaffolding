using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvxNative.Core.ViewModels.Main;
using UIKit;

namespace MvxNative.iOS.Views.Main
{
    [MvxFromStoryboard(nameof(MainViewController))]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainViewController : MvxViewController<MainViewModel>
    {
        public MainViewController(IntPtr handle) : base(handle)
        {
        }
    }
}
