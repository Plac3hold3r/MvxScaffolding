using MvvmCross.Core.ViewModels;
using MvvmCross.Uwp.Attributes;
using MvvmCross.Uwp.Views;
using MvxNative.Core.ViewModels.Main;

namespace MvxNative.UWP
{
    [MvxPagePresentation]
    [MvxViewFor(typeof(MainViewModel))]
    public sealed partial class MainPage : MvxWindowsPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
