using System;
using System.Collections.Generic;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<BasketProductDto> OrderProducts { get; set; } 
    }
}
