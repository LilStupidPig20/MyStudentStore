using RTF.Mobile.Utils.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace RTF.Mobile.ViewModels.Shop
{
    public class ShopModel : EditableModel
    {
        public ObservableCollection<ShopItemPreviewModel> ItemsWithSearchFilter { get; set; } = new ObservableCollection<ShopItemPreviewModel>();

        public IEnumerable<ShopItemPreviewModel> Items { get; set; } = Enumerable.Empty<ShopItemPreviewModel>();

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

        private string searchText = string.Empty;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public ShopModel()
        {
            this.PropertyChanged += ShopModel_PropertyChanged;
        }

        private void ShopModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchText))
            {
                ItemsWithSearchFilter.Clear();
                var itemsWithFilter = Items
                    .Where(i => i.Name
                    .Contains(SearchText));
                foreach (var item in itemsWithFilter)
                {
                    ItemsWithSearchFilter.Add(item);
                }
            }
        }
    }
}
