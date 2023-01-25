using RTF.Mobile.Utils.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Drawing.Imaging;
using System.Linq;

namespace RTF.Mobile.ViewModels.Basket
{
    public class BasketModel : EditableModel
    {
        public ObservableCollection<BasketItemModel> BasketItemModels { get; set; }

        private int itemsCount;
        public int ItemsCount
        {
            get => itemsCount;

            set
            {
                itemsCount = value;
                OnPropertyChanged(nameof(ItemsCount));
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

        private bool isAllItemsSelected;

        public bool IsAllItemsSelected
        {
            get
            {
                return isAllItemsSelected;
            }
            set
            {
                isAllItemsSelected = value;
                if (isAllItemsSelected)
                {
                    UnsubscribeFromItemModels();
                    foreach (var item in BasketItemModels)
                    {
                        item.IsSelected = true;
                    }
                    RecalculatePrice();
                    SubscribeToItemModels();
                }
                else
                {
                    UnsubscribeFromItemModels();
                    foreach (var item in BasketItemModels)
                    {
                        item.IsSelected = false;
                    }
                    RecalculatePrice();
                    SubscribeToItemModels();
                }
                OnPropertyChanged(nameof(IsAllItemsSelected));
            }
        }

        public BasketModel()
        {
        }

        public void SubscribeToItemModels()
        {
            foreach (var item in BasketItemModels)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        public void UnsubscribeFromItemModels()
        {
            foreach (var item in BasketItemModels)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BasketItemModel.IsSelected))
            {
                var basketItem = (BasketItemModel)sender;
                if (!basketItem.IsSelected && IsAllItemsSelected)
                {
                    IsAllItemsSelected = false;
                }
                RecalculatePrice();
            }
        }

        public void RecalculatePrice()
        {
            TotalPrice = BasketItemModels.Where(item => item.IsSelected)
                    .Sum(item => item.ItemPrice * item.Count);
            ItemsCount = BasketItemModels.Where(item => item.IsSelected)
                .Sum(item => item.Count);
        }
    }
}
