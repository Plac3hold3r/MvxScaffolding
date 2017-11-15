using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;

namespace MvxNative.iOS.Views
{
    public abstract class BaseViewController<TViewModel> : MvxViewController<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}
