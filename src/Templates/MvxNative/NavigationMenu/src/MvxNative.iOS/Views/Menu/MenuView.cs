using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using MvvmCross.Plugin.Sidebar;
using MvvmCross.Plugin.Sidebar.Views;
using MvxNative.Core.ViewModels.Menu;
using UIKit;

namespace MvxNative.iOS.Views.Menu
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public class MenuView : BaseViewController<MenuViewModel>, IMvxSidebarMenu
    {
        private UILabel _menuHome, _menuSettings;

        public bool AnimateMenu => true;

        public bool DisablePanGesture => false;

        public float DarkOverlayAlpha => 0;

        public bool HasDarkOverlay => false;

        public bool HasShadowing => true;

        public float ShadowOpacity => 0.5f;

        public float ShadowRadius => 4.0f;

        public UIColor ShadowColor => UIColor.Black;

        public UIImage MenuButtonImage => UIImage.FromBundle("Images/ic_menu");

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

        protected override void CreateView()
        {
            _menuHome = new UILabel
            {
                Text = "Home"
            };
            Add(_menuHome);

            _menuSettings = new UILabel
            {
                Text = "Settings"
            };
            Add(_menuSettings);
        }

        protected override void LayoutView()
        {
            NSObject topGuide = UIDevice.CurrentDevice.CheckSystemVersion(11, 0) ? 
                View.SafeAreaLayoutGuide : View.LayoutMarginsGuide;
            
            View.AddConstraints(new FluentLayout[]
            {
                _menuHome.Top().EqualTo().TopOf(topGuide).Plus(25f),
                _menuHome.AtLeftOf(View, 10f),
                _menuHome.AtLeftOf(View, 10f),
                _menuHome.ToRightOf(View),

                _menuSettings.Below(_menuHome, 10f),
                _menuSettings.AtLeftOf(View, 10f),
                _menuSettings.ToRightOf(View)
            });
        }

        protected override void BindView()
        {
            MvxFluentBindingDescriptionSet<MenuView, MenuViewModel>
                bindingSet = this.CreateBindingSet<MenuView, MenuViewModel>();

            bindingSet.Bind(_menuHome.Tap()).For(v => v.Command).To(vm => vm.ShowHomeCommand);
            bindingSet.Bind(_menuSettings.Tap()).For(v => v.Command).To(vm => vm.ShowSettingsCommand);

            bindingSet.Apply();
        }
    }
}
