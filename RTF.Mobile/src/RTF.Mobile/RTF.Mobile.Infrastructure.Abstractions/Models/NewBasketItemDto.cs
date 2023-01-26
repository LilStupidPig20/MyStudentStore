using System;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class NewBasketItemDto
    {
        public Guid ProductId { get; set; }

        public int Count { get; set; }

        public SizeType? Size { get; set; }
    }
}
