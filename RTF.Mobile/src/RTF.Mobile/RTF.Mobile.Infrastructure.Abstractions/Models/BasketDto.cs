using System.Collections.Generic;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class BasketDto
    {
        public int TotalPrice { get; set; }

        public IEnumerable<BasketProductDto> BasketProducts { get; set; }
    }
}
