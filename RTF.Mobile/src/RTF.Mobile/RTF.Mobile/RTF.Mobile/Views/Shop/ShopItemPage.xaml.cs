using RTF.Mobile.ViewModels.Profile;
using RTF.Mobile.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Shop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShopItemPage : ContentPage
	{
		public ShopItemPage ()
		{
			InitializeComponent ();

			BindingContext = new ShopItemViewModel();
		}

        protected override void OnDisappearing()
        {
			base.OnDisappearing();
            
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (e.Value)
			{
				var button = sender as RadioButton;
				var collection = this.FindByName<CollectionView>("SizesCollection");
				var size = button.Value as ShopItemSizeType;
                collection.SelectedItem = size;
            }
        }
    }
}