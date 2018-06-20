using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Plugin.Sidebar;
using MvvmCross.Plugin.Sidebar.Views;
using MvxNative.Core.ViewModels.Menu;
using UIKit;

namespace MvxNative.iOS.Views.Menu
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public class MenuView : BaseViewController<MenuViewModel>, IMvxSidebarMenu
    {
        public MenuView(IntPtr handle) : base(handle)
        {
        }

        public bool AnimateMenu => true;

        public bool DisablePanGesture => false;

        public float DarkOverlayAlpha => 0;

        public bool HasDarkOverlay => false;

        public bool HasShadowing => true;

        public float ShadowOpacity => 0.5f;

        public float ShadowRadius => 4.0f;

        public UIColor ShadowColor => UIColor.Black;

        public UIImage MenuButtonImage => UIImage.FromBundle("Images/nav_icon_menu");

        public int MenuWidth => 265;

        public bool ReopenOnRotate => true;

        public void MenuDidClose()
        {
            // Method intentionally left empty.
        }

        public void MenuDidOpen()
        {
            // Method intentionally left empty.
        }

        public void MenuWillClose()
        {
            // Method intentionally left empty.
        }

        public void MenuWillOpen()
        {
            // Method intentionally left empty.
        }
    }
}
