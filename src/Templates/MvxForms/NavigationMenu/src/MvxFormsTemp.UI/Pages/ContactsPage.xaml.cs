using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxFormsTemp.Core.ViewModels.Contacts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvxFormsTemp.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Contacts Page")]
    public partial class ContactsPage : MvxContentPage<ContactsViewModel>
    {
		public ContactsPage ()
		{
			InitializeComponent ();
		}
	}
}
