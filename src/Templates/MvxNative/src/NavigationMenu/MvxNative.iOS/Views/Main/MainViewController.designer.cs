// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MvxNative.iOS.Views.Main
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelWelcome { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelMessage != null) {
                LabelMessage.Dispose ();
                LabelMessage = null;
            }

            if (LabelWelcome != null) {
                LabelWelcome.Dispose ();
                LabelWelcome = null;
            }
        }
    }
}