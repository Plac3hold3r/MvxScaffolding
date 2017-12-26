using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using MvxFormsTemp.Core.ViewModels.Home;
using Xamarin.Forms;

namespace MvxFormsTemp.Core.Pages
{
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
