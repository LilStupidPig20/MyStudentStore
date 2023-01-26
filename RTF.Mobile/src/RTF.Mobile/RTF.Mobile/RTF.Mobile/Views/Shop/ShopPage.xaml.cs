using RTF.Mobile.ViewModels.Shop;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTF.Mobile.Views.Shop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShopPage : ContentPage
	{
		public ShopPage ()
		{
			this.InitializeComponent();
			this.BindingContext = new ShopViewModel();
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			var shopItem = e.SelectedItem as ShopItemPreviewModel;
			var shopViewModel = (ShopViewModel)BindingContext;
			shopViewModel.OpenShopItemCommand.Execute(shopItem.Id);
        }

        private void RefreshView_Refreshing(object sender, System.EventArgs e)
        {
            var shopViewModel = (ShopViewModel)BindingContext;
            shopViewModel.UpdateItemsCommand.Execute(this);
        }
    }
}