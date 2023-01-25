using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System;
using Xamarin.Forms.Internals;

namespace RTF.Mobile.ViewModels.Basket
{
    public class BasketViewModel : EditableViewModel
    {
        private IApiService apiService;

        public Command<Guid> RemoveItemCommand { get; }

        public Command<Guid> IncremenentCountCommand { get; }

        public Command<Guid> DecrementCountCommand { get; }

        public Command MakeOrderCommand { get; }

        public BasketModel Model { get; set; }

        public BasketViewModel()
        {
            RemoveItemCommand = new Command<Guid>(RemoveItemCommandExecute);
            IncremenentCountCommand = new Command<Guid>(IncrementCountCommandExecute);
            DecrementCountCommand = new Command<Guid>(DecrementCountCommandExecute);
            MakeOrderCommand = new Command(MakeOrderCommandExecute);
        }

        public override async Task LoadAsync()
        {
            apiService = DependencyService.Get<IApiService>();

            var basket = await apiService.GetBasketAsync();
            Model = new BasketModel()
            {
                ItemsCount = 0,
                TotalPrice = 0,
                BasketItemModels = new ObservableCollection<BasketItemModel>(basket.BasketProducts.Select(bp => new BasketItemModel()
                {
                    BasketId = bp.BasketProductId,
                    ProductId = bp.StoreProductId,
                    Name = bp.Name,
                    Description = bp.Description,
                    ImageSource = bp.ImageSource,
                    Count = bp.Count,
                    ItemPrice = bp.ProductPrice,
                    Size = bp.SizeType,
                })),
            };
            Model.SubscribeToItemModels();
        }

        private async void MakeOrderCommandExecute()
        {
            var userPoints = await apiService.GetCurrentUserBalanceAsync();
            if (userPoints < Model.TotalPrice)
            {
                await Shell.Current.DisplayAlert("Ошибка!", "Для покупки не хватает баллов", "Ок");
                return;
            }
            var basketModels = Model.BasketItemModels
                .Where(item => item.IsSelected)
                .ToList();
            await apiService.MakeOrder(basketModels
                .Select(item => item.BasketId));
            foreach (var basketModel in basketModels) 
            {
                Model.BasketItemModels.Remove(basketModel);
            }
            await Shell.Current.DisplayAlert("Оплата прошла успешно!", "Для продолжнения покупок, перейдите в магазин", "Ок");
        }

        private async void IncrementCountCommandExecute(Guid id)
        {
            await apiService.IncrementProductCountAsync(new NewBasketItemDto()
            {
                ProductId = id,
            });
            var item = Model.BasketItemModels.FirstOrDefault(i => i.BasketId == id);
            item.Count++;
            if (item.IsSelected)
            {
                Model.RecalculatePrice();
            }
        }

        private async void  DecrementCountCommandExecute(Guid id)
        {
            await apiService.DecrementProductCountAsync(new NewBasketItemDto()
            {
                ProductId = id,
            });
            var item = Model.BasketItemModels.FirstOrDefault(i => i.BasketId == id);
            item.Count--;
            if (item.IsSelected)
            {
                Model.RecalculatePrice();
            }
        }

        private async void RemoveItemCommandExecute(Guid id)
        {
            await apiService.RemoveItemFromBasketAsync(new NewBasketItemDto()
            {
                ProductId = id,
            });
            var item = Model.BasketItemModels.FirstOrDefault(i => i.BasketId == id);
            Model.BasketItemModels.Remove(item);
        }
    }
}
