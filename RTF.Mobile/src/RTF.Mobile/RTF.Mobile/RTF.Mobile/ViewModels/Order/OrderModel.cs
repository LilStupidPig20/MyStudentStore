using RTF.Mobile.Utils.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RTF.Mobile.ViewModels.Order
{
    public class OrderModel : EditableModel
    {
        public ObservableCollection<OrderItemModel> Orders { get; set; }
    }
}
