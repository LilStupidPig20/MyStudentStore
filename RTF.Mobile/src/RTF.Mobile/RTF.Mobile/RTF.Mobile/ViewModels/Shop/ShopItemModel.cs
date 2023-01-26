using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Shop
{
    public class ShopItemModel : EditableModel
    {
        private int orderedItems;

        public int OrderedItems
        {
            get => orderedItems;
            set
            {
                orderedItems = value;
                OnPropertyChanged(nameof(OrderedItems));
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public bool HasSizes => SizeTypes.Any(st => st.IsPresented);

        public SizeType? SelectedSizeType { get; set; }

        public ShopItemSizeType SelectedSize { get; set; }

        public ImageSource ImageSource { get; set; }

        public IEnumerable<ShopItemSizeType> SizeTypes { get; set; } = Enumerable.Empty<ShopItemSizeType>();
    }
}
