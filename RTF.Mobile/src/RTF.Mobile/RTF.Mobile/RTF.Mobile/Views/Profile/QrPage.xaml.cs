using RTF.Mobile.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrPage : ContentPage
    {
        public QrPage()
        {
            InitializeComponent();

            this.BindingContext = new QrViewModel();
        }
    }
}