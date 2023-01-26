using System;
using Xamarin.Forms;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class BasketProductDto
    {
        public Guid BasketProductId { get; set; }

        public Guid StoreProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ProductPrice { get; set; }

        public int Count { get; set; }

        public ImageSource ImageSource { get; set; }

        public SizeType? SizeType { get; set; }
    }
}
