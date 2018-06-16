using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using MvxFormsTemp.Core.ViewModels.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvxFormsTemp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.BarTextColor = Color.White;
                navigationPage.BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            }
        }
    }
}
