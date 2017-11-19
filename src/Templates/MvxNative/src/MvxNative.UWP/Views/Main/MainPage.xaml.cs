using MvvmCross.Core.ViewModels;
using MvvmCross.Uwp.Views;
using MvxNative.Core.ViewModels.Main;

namespace MvxNative.UWP
{
    [MvxViewFor(typeof(MainViewModel))]
    public sealed partial class MainPage : MvxWindowsPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
