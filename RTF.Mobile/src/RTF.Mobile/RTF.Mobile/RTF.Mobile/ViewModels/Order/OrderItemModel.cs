using RTF.Mobile.Infrastructure.Abstractions.Exceptions;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RTF.Mobile.ViewModels.Order
{
    public class OrderItemModel : EditableModel
    {
        private int totalCount;

        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                OnPropertyChanged(nameof(TotalCount));
            }
        }

        private int totalPrice;

        public int TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public Guid Id { get; set; }

        private OrderStatus orderStatus;

        public OrderStatus Status
        {
            get => orderStatus;
            set
            {
                orderStatus = value;
                UpdateIsCancellationPossible();
                OnPropertyChanged(nameof(Status));
            }
        }

        private bool isCancellationPossible;

        public bool IsCancellationPossible
        {
            get => isCancellationPossible;
            set
            {
                isCancellationPossible = value;
                OnPropertyChanged(nameof(IsCancellationPossible));
            }
        }

        public IEnumerable<BasketProductDto> Items { get; set; } = Enumerable.Empty<BasketProductDto>();

        public void UpdateIsCancellationPossible()
        {
            IsCancellationPossible = Status == OrderStatus.InProgress || Status == OrderStatus.Pending;
        }

        public void UpdateTotalValues()
        {
            TotalCount = Items.Sum(bp => bp.Count);
            TotalPrice = Items.Sum(bp => bp.Count * bp.ProductPrice);
        }
    }
}
