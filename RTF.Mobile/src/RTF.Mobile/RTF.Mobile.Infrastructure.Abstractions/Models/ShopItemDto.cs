using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class ShopItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Price { get; set; }

        public bool NotAvailable { get; set; }

        public ImageSource ImageSource { get; set; }

        public ShopItemDto()
        {
        }

        public IEnumerable<SizeType> AvailableSizeTypes { get; set; }
    }

    public enum SizeType
    {
        XS,
        S,
        M,
        L,
        XL,
    }
}
