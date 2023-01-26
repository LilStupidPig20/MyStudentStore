using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Utils.PageInt;
using RTF.Mobile.Views.Order;
using RTF.Mobile.Views.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Shop
{
    public class ShopViewModel : BaseViewModel, IShellViewModel
    {
        private readonly IApiService apiService;

        public ShopModel Model { get; set; } = new ShopModel();

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        private object selectedItem;

        public object SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public Command RefreshCommand { get; }

        public Command UpdateItemsCommand { get; }

        public Command GoToBasketCommand { get; }

        public Command<Guid> OpenShopItemCommand { get; }

        public ShopViewModel() : base()
        {
            apiService = DependencyService.Get<IApiService>();
            UpdateItemsCommand = new Command(UpdateItemsCommandExecute);
            OpenShopItemCommand = new Command<Guid>(OpenShopItemExecuteAsync);
            RefreshCommand = new Command(RefreshItemsCommandExecute);
            UpdateItemsCommandExecute();
        }

        private async void UpdateItemsCommandExecute()
        {
            Model = new ShopModel();
            var shopItems =  await apiService.GetShopItems(CancellationToken.None);
            var shopPreviewItems = new List<ShopItemPreviewModel>();
            foreach (var shopItem in shopItems)
            {
                shopPreviewItems.Add(new ShopItemPreviewModel(shopItem.Id, shopItem.Name, shopItem.Price, shopItem.ImageSource));
            }
            Model.Items = shopPreviewItems;
            Model.OrderedItems = GetOrderedItemsCount(await apiService.GetBasketAsync());
            Model.ItemsWithSearchFilter = new ObservableCollection<ShopItemPreviewModel>(Model.Items.Where(i => i.Name.Contains(Model.SearchText)));
        }

        private async void RefreshItemsCommandExecute()
        {
            IsRefreshing = true;
            var shopItems = await apiService.GetShopItems(CancellationToken.None);
            var shopPreviewItems = new List<ShopItemPreviewModel>();
            foreach (var shopItem in shopItems)
            {
                shopPreviewItems.Add(new ShopItemPreviewModel(shopItem.Id, shopItem.Name, shopItem.Price, shopItem.ImageSource));
            }
            Model.Items = shopPreviewItems;
            foreach (var shopItem in Model.ItemsWithSearchFilter.ToList())
            {
                Model.ItemsWithSearchFilter.Remove(shopItem);
            }
            foreach (var shopItem in Model.Items)
            {
                Model.ItemsWithSearchFilter.Add(shopItem);
            }
            Model.OrderedItems = GetOrderedItemsCount(await apiService.GetBasketAsync());
            Model.SearchText = string.Empty;
            SelectedItem = null;
            IsRefreshing = false;
        }

        private static int GetOrderedItemsCount(BasketDto basket)
        {
            var totalCount = 0;
            foreach (var basketItem in basket.BasketProducts)
            {
                totalCount += basketItem.Count;
            }
            return totalCount;
        }

        private async void OpenShopItemExecuteAsync(Guid id)
        {
            MockApiService.CurrentlyOpenedItemId = id;
            await Shell.Current.GoToAsync(nameof(ShopItemPage), true);
        }

        private async void GoToBasketCommandExecuteAsync()
        {
            await Shell.Current.GoToAsync(nameof(OrderPage), true);
        }
    }
}
