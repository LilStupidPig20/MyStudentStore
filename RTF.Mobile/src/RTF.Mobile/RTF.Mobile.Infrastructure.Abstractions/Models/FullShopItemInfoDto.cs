using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class FullShopItemInfoDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public ImageSource ImageSource { get; set; }

        public bool NotAvailable { get; set; }

        public int Price { get; set; }

        public bool HasSizes => AvailableSizes.Any();

        public IEnumerable<SizeType> AvailableSizes = Enumerable.Empty<SizeType>();
    }
}
