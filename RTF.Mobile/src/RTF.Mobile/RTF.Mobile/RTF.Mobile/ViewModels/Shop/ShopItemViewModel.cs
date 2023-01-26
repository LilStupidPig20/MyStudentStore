using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.MockServices;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Views.Basket;
using RTF.Mobile.Views.Shop;
using Saritasa.Tools.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Shop
{
    public class ShopItemViewModel : EditableViewModel
    {
        private IApiService apiService;

        public Command GoToBasketCommand { get; }

        public Command AddToBasketCommand { get; }

        public Command BuyCommand { get; }

        public ShopItemModel Model { get; set; }

        public IEnumerable<SizeType> SizeTypes => EnumUtils.GetValues<SizeType>();

        public ShopItemViewModel()
        {
            GoToBasketCommand = new Command(GoToBasketCommandExecute);
            AddToBasketCommand = new Command(AddToBasketCommandExecute);
            BuyCommand = new Command(BuyCommandExecute);
        }

        public void OnDisappearing()
        {
            IsBusy = false;
        }

        public override async Task LoadAsync()
        {
            apiService = DependencyService.Get<IApiService>();

            var item = await apiService.GetShopItemInfoDto(MockApiService.CurrentlyOpenedItemId);
            Model = new ShopItemModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ImageSource = item.ImageSource,
                Price = item.Price,
                SizeTypes = SizeTypes.Select(st => new ShopItemSizeType()
                {
                    SizeType = st,
                    IsPresented = item.AvailableSizes.Contains(st),
                }),
                OrderedItems = GetOrderedItemsCount(await apiService.GetBasketAsync()),
            };
        }

        private async void AddToBasketCommandExecute()
        {
            await apiService.AddItemToBasketAsync(new NewBasketItemDto()
            {
                Count = 1,
                ProductId = Model.Id,
                Size = Model.SelectedSize?.SizeType,
            });
            await Shell.Current.DisplayAlert("Успех!", "Товар добавлен в корзину", "Ок");
            Model.OrderedItems = GetOrderedItemsCount(await apiService.GetBasketAsync());
        }

        private async void BuyCommandExecute()
        {
        }

        private async void GoToBasketCommandExecute()
        {
            await Shell.Current.GoToAsync(nameof(BasketPage));
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
    }
}
