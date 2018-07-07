using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Plugin.Sidebar;
using MvxNative.Core.ViewModels.Settings;
using UIKit;

namespace MvxNative.iOS.Views.Settings
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class SettingsView : BaseViewController<SettingsViewModel>
    {
        public SettingsView(IntPtr handle) : base(handle)
        {
        }
    }
}
