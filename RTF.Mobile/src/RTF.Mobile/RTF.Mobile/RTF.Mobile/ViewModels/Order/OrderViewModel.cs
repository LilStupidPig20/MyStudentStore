using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Utils.Models;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Security.Cryptography;
using RTF.Mobile.Utils.PageInt;

namespace RTF.Mobile.ViewModels.Order
{
    public class OrderViewModel : EditableViewModel, IShellViewModel
    {
        private IApiService apiService;

        public Command<Guid> CancelOrderCommand { get; }

        public OrderModel Model { get; set; }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public Command RefreshCommand { get; }

        public OrderViewModel() 
        {
            CancelOrderCommand = new Command<Guid>(CancelOrderCommandExecuteAsync);
            RefreshCommand = new Command(RefreshCommandExecute);
        }

        public override async Task LoadAsync()
        {
            apiService = DependencyService.Get<IApiService>();
            var orders = await apiService.GetOrdersAsync();
            Model = new OrderModel();
            Model.Orders = new ObservableCollection<OrderItemModel>(orders.Select(ord => new OrderItemModel()
            {
                Id = ord.Id,
                Status = ord.Status,
                Items = ord.OrderProducts,
            }));
            foreach (var item in Model.Orders)
            {
                item.UpdateIsCancellationPossible();
                item.UpdateTotalValues();
            }
        }

        private async void RefreshCommandExecute()
        {
            IsRefreshing = true;
            var orders = await apiService.GetOrdersAsync();
            foreach (var item in Model.Orders.ToList())
            {
                Model.Orders.Remove(item);
            }
            foreach (var item in orders)
            {
                Model.Orders.Add(new OrderItemModel()
                {
                    Id = item.Id,
                    Status = item.Status,
                    Items = item.OrderProducts,
                });
            }
            foreach (var item in Model.Orders)
            {
                item.UpdateIsCancellationPossible();
                item.UpdateTotalValues();
            }
            IsRefreshing = false;
        }

        private async void CancelOrderCommandExecuteAsync(Guid id)
        {
            var result = await Shell.Current.DisplayAlert("Отменить заказ?", "Вы уверены, что хотите отменить заказ?", "Да", "Нет");
            if (!result)
            {
                return;
            }
            await apiService.CancelOrderAsync(id);
            var order = Model.Orders.FirstOrDefault(o => o.Id == id);
            order.Status = OrderStatus.Cancelled;
        }
    }
}
