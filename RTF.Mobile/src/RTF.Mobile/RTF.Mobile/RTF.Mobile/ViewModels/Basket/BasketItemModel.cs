using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.Models;
using System;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Basket
{
    public class BasketItemModel : EditableModel
    {
        public Guid BasketId { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        private int count;

        public int Count 
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public int ItemPrice { get; set; }

        public string Description { get; set; }

        public SizeType? Size { get; set; }

        public ImageSource ImageSource { get; set; }

        private bool isSelected;

        public bool IsSelected 
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
