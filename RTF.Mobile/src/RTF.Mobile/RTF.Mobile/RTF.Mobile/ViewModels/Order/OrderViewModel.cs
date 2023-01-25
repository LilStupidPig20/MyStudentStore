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

namespace RTF.Mobile.ViewModels.Order
{
    public class OrderViewModel : EditableViewModel
    {
        private IApiService apiService;

        public Command<Guid> CancelOrderCommand { get; }

        public OrderModel Model { get; set; }

        public OrderViewModel() 
        {
            CancelOrderCommand = new Command<Guid>(CancelOrderCommandExecuteAsync);
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

        private async void CancelOrderCommandExecuteAsync(Guid id)
        {
            await apiService.CancelOrderAsync(id);
            var order = Model.Orders.FirstOrDefault(o => o.Id == id);
            order.Status = OrderStatus.Cancelled;
        }
    }
}
