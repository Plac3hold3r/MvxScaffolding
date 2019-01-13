using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxFormsTemp.Core.ViewModels.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvxFormsTemp.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "NavigationMenu")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
		public MenuPage ()
		{
			InitializeComponent ();
		}
	}
}
