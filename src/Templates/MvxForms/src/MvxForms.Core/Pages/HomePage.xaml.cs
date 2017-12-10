using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using MvxForms.Core.ViewModels.Home;
using Xamarin.Forms;

namespace MvxForms.Core.Pages
{
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
