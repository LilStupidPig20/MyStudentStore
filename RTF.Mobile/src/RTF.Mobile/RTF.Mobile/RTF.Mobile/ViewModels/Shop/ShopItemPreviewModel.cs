using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RTF.Mobile.ViewModels.Shop
{
    public class ShopItemPreviewModel
    {
        public Guid Id { get; }

        public string Name { get; }

        public int Price { get; }

        public ImageSource ImageSource { get; }

        public ShopItemPreviewModel(Guid id, string name, int price, ImageSource imageSource)
        {
            Id = id;
            Name = name;
            Price = price;
            ImageSource = imageSource;
        }
    }
}
